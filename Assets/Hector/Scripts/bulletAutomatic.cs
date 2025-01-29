using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletAutomatic : MonoBehaviour
{
    
    public GameObject balaPrefab;           
    public Transform puntoDeDisparo;        
    public float fuerzaDisparo = 500f;     
    public float tiempoEntreDisparos = 0.1f; 

    private float tiempoUltimoDisparo = 0f;  

    void Update()
    {
      
        if (Input.GetMouseButton(0)) 
        {
           
            if (Time.time - tiempoUltimoDisparo >= tiempoEntreDisparos)
            {
                Disparar();
                tiempoUltimoDisparo = Time.time; 
            }
        }
    }

    void Disparar()
    {
        
        GameObject bala = Instantiate(balaPrefab, puntoDeDisparo.position, puntoDeDisparo.rotation);

        
        Rigidbody rb = bala.GetComponent<Rigidbody>();
        if (rb != null)
        {
            
            rb.AddForce(puntoDeDisparo.forward * fuerzaDisparo, ForceMode.Impulse);
        }
    }
}
