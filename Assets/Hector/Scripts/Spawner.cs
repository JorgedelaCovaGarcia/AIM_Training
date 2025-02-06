using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject zombiePrefab;

    
    public float tiempoDeGeneracion = 3f;

    
    public Transform posicionGeneracion;

   
    public int maxZombies = 4;

    
    private int contadorZombies = 0;

    void Start()
    {
       
        InvokeRepeating("GenerarZombie", 6f, tiempoDeGeneracion);
    }

    void GenerarZombie()
    {
        
        if (contadorZombies < maxZombies)
        {
            
            Instantiate(zombiePrefab, posicionGeneracion.position, Quaternion.identity);

           
            contadorZombies++;

            Debug.Log("Zombies generados: " + contadorZombies);
        }
        else
        {
            
            Debug.Log("Se ha alcanzado el límite de zombies.");
        }
    }
}
