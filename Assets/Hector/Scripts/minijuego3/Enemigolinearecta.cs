using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigolinearecta : MonoBehaviour
{
    
    public float speed = 2.0f;  
    public float zigzagStrength = 2f;  
    private Vector3 direction;  
    private float zigzagDirection;  

    void Start()
    {
        
        direction = new Vector3(-1, 0, 1);  

        
        zigzagDirection = Random.Range(-2f, 2f);  
    }

    void Update()
    {
        
        float horizontalMovement = Mathf.Sin(Time.time * speed) * zigzagStrength * zigzagDirection; 

        
        transform.Translate(new Vector3(horizontalMovement, 0, 1) * speed * Time.deltaTime);
    }
}
