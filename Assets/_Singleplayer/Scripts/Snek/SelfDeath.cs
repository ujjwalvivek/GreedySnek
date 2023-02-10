using System.Collections.Generic;
using UnityEngine;

public class SelfDeath : MonoBehaviour
{
    private SnekController snekController;
    private GameObject gameOver;
    private List<GameObject> bodyParts = new List<GameObject>();
    
    void Start()
    {
        snekController = this.GetComponentInParent<SnekController>();
        gameOver = snekController.gameOver;
        bodyParts = snekController.bodyParts;
    }
    
    void Update()
    {
        Invoke(nameof(SnekHeadCollision), 2f);
    }
    
    private void SnekHeadCollision()
    {
        for (int i = 0; i < bodyParts.Count; i++)
        {
            if (bodyParts[i] != null && bodyParts[i] != this.gameObject && 
                this.gameObject.GetComponent<Collider>().bounds.Intersects(bodyParts[i].GetComponent<Collider>().bounds))
            {
                gameOver.gameObject.SetActive(true);
                Destroy(this);
            }
        }
    }
}
