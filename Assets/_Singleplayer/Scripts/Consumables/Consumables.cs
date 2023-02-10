using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Consumables : MonoBehaviour
{
    [SerializeField] private GameObject consumableApple;

    public int spawnCounter;
    private GameObject currentConsumable;
    
    private void Start()
    {
        spawnCounter = 0;
        SpawnApple();
    }

    private void SpawnApple()
    {
        var x = Random.Range(-1f, -14f);
        var z = Random.Range(-1f, -14f);
        var spawnPos = new Vector3(x, 1f, z);
        
        currentConsumable = Instantiate(consumableApple, spawnPos, Quaternion.identity);
        
        if (spawnCounter % 2 != 0)
        {
            int randomAxis = Random.Range(0, 2);
            currentConsumable.AddComponent<MovingApple>();
        }
        spawnCounter++;
        Debug.Log("First" +spawnCounter);
    }
    
    public void RemoveApple()
    {
        Destroy(currentConsumable);
        SpawnApple();
    }
}

public class MovingApple : MonoBehaviour
{
    private Vector3 startPos;
    private Vector3 endPos;
    private float moveSpeed = 2f;

    private void Start()
    {
        // randomly choose the axis to move along (x or z)
        int axis = Random.Range(0, 2);

        // randomly choose the direction to move (positive or negative)
        int direction = 1;
        
        
        // pick a random floating point number
        var random = Random.Range(-1f, -14f);

        // set start and end positions based on chosen axis and direction
        switch (axis)
        {
            case 0:
                startPos = new Vector3(-1f * direction, 1f, random);
                endPos = new Vector3(-14f * direction, 1f, random);
                break;
            case 1:
                startPos = new Vector3(random, 1f, -1f * direction);
                endPos = new Vector3(random, 1f, -14f * direction);
                break;
        }

        // move the apple from start to end position
        transform.position = startPos;
        StartCoroutine(MoveApple());
    }

    private IEnumerator MoveApple()
    {
        while (true)
        {
            transform.position = Vector3.MoveTowards(transform.position, endPos, moveSpeed * Time.deltaTime);
            if (transform.position == endPos)
            {
                // switch direction when apple reaches end position
                (startPos, endPos) = (endPos, startPos);
            }
            yield return null;
        }
    }
}
