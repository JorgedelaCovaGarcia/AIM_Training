using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RealBullet : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log("Atravieso algo!");
        if (collision.gameObject.CompareTag("Sphere"))
        {
            Debug.Log("Tocado!!");
            Destroy(this.gameObject);
            Destroy(collision.gameObject);
        }
    }
}
