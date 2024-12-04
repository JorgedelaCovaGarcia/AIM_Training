using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering;


public class FruitSpawner : MonoBehaviour
{
    public GameObject fruitPrefab; // Prefab de la fruta
    public float spawnRate = 2.0f; // Tiempo entre spawns
    public Vector3 spawnArea = new Vector3(10, 0, 10); // Tama�o del �rea de spawn

    void Start()
    {
        // Inicia el spawn repetitivo
        InvokeRepeating("SpawnFruit", 0, spawnRate);
    }

    void SpawnFruit()
    {
        // Genera una posici�n aleatoria dentro del �rea de spawn
        Vector3 spawnPosition = new Vector3(
            Random.Range(-spawnArea.x / 2, spawnArea.x / 2),
            transform.position.y,
            Random.Range(-spawnArea.z / 2, spawnArea.z / 2)
        );

        // Instancia la fruta
        Instantiate(fruitPrefab, spawnPosition, Quaternion.identity);
        Quaternion randomRotation = Quaternion.Euler(0, Random.Range(0, 360), 0);
        Instantiate(fruitPrefab, spawnPosition, randomRotation);
    }

    void OnDrawGizmosSelected()
    {
        // Dibuja el �rea de spawn en el editor para visualizaci�n
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position, new Vector3(spawnArea.x, 1, spawnArea.z));
    }
}
