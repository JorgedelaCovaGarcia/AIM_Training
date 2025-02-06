using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombieizqaderecha : MonoBehaviour
{
   
    public float speed = 2.0f;  
    private float moveDirection = 1.0f; 

    public int health = 1;  
    private bool isDead = false;



    void Start()
    {
        
        
    }

    void Update()
    {
        if (isDead) return; 

        
        transform.Translate(Vector3.right * speed * moveDirection * Time.deltaTime);

        
        if (transform.position.x > 10f) 
        {
            moveDirection = -1f; 
            Flip(); 

        }
        else if (transform.position.x < -10f) 
        {
            moveDirection = 1f; 
            Flip(); 
        }

    }

    
    void Flip()
    {
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

  
    public void TakeDamage(int damage)
    {
        if (isDead) return; 

        health -= damage;  

        if (health <= 0)
        {
            Die();  
        }
    }

    
    void Die()
    {
        isDead = true; 
      
        Destroy(gameObject); 
    }
     
}
