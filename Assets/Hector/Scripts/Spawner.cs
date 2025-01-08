using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject zombiePrefab;

    // Tiempo de espera para generar un zombie
    public float tiempoDeGeneracion = 3f;

    // Posición de aparición
    public Transform posicionGeneracion;

    // Número máximo de zombies que pueden aparecer
    public int maxZombies = 3;

    // Contador de zombies generados
    private int contadorZombies = 0;

    void Start()
    {
        // Llama a la función GenerarZombie después de un tiempo inicial y luego repetidamente
        InvokeRepeating("GenerarZombie", 0f, tiempoDeGeneracion);
    }

    void GenerarZombie()
    {
        // Verifica que no se haya alcanzado el límite de zombies
        if (contadorZombies < maxZombies)
        {
            // Instancia el zombie en la posición especificada
            Instantiate(zombiePrefab, posicionGeneracion.position, Quaternion.identity);

            // Incrementa el contador de zombies generados
            contadorZombies++;

            Debug.Log("Zombies generados: " + contadorZombies);
        }
        else
        {
            // Si se alcanza el límite, muestra un mensaje en la consola
            Debug.Log("Se ha alcanzado el límite de zombies.");
        }
    }
}
