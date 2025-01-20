using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject balaPrefab;    
    public Transform puntoDeDisparo; 
    public float fuerzaDisparo = 500f; 

    void Update()
    {
       
        if (Input.GetMouseButtonDown(0)) 
        {
            Disparar();
        }
    }

    void Disparar()
    {
       
        GameObject bala = Instantiate(balaPrefab, puntoDeDisparo.position, puntoDeDisparo.rotation);


        Rigidbody rb = bala.GetComponent<Rigidbody>();
        if (rb != null)
        {
            
            rb.AddForce(puntoDeDisparo.forward * fuerzaDisparo);
        }
    }
}
