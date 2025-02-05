using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RealBullet : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log("Atravieso algo!" + collision.name);
        
        if (collision.gameObject.CompareTag("Sphere"))
        {
            Debug.Log("Tocado!!");
            Destroy(collision.gameObject);
        }
    }
}
