using System;
using System.Collections.Generic;
using UnityEngine;

public class SnekController : MonoBehaviour
{
    public float moveSpeed;
    public float steerSpeed;
    public float bodySpeed;
    public int bodyGap;
    
    public GameObject bodyPrefab;

    //Using a List to grow the snek :)
    public List<GameObject> bodyParts = new List<GameObject>();
    private List<Vector3> posHistory = new List<Vector3>();

    public GameObject gameOver;

    private void Start() 
    {
        GrowSnake();
    }

    void Update() 
    {
        MoveSnek();
    }

    private void FixedUpdate()
    {
        // Store position history
        posHistory.Insert(0, this.transform.position);
    }

    public void GrowSnake() 
    {
        // Instantiate body instance and add it to the list
        GameObject body = Instantiate(bodyPrefab);
        bodyParts.Add(body);
    }

    private void MoveSnek()
    {
        var snekPos = transform;
        
        // Move forward and Steer
        // snekPos.position += snekPos.forward * (moveSpeed * Time.deltaTime);
        // float steerDirection = Input.GetAxis("Horizontal");
        // snekPos.Rotate(Vector3.up * (steerDirection * steerSpeed * Time.deltaTime));
        
        snekPos.position += snekPos.forward * (moveSpeed * Time.deltaTime);
        float steerDirection = 0f;
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.position.x < Screen.width / 2f)
            {
                steerDirection = -1f;
            }
            else
            {
                steerDirection = 1f;
            }
        }
        else
        {
            steerDirection = Input.GetAxis("Horizontal");
        }
        snekPos.Rotate(Vector3.up * (steerDirection * steerSpeed * Time.deltaTime));

        // Move body parts
        int index = 0;
        foreach (var body in bodyParts) 
        {
            Vector3 point = posHistory[Mathf.Clamp(index * bodyGap, 0, posHistory.Count - 1)];

            // Move and Rotate the body towards the point along the snakes path
            Vector3 moveDirection = point - body.transform.position;
            body.transform.position += moveDirection * (bodySpeed * Time.deltaTime);
            body.transform.LookAt(point);

            index++;
        }
    }
}



