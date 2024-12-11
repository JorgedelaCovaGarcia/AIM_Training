using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject spherePrefab;  // Prefab de la esfera
    public Vector3 spawnAreaCenter;  // Centro de la zona de spawn
    public Vector3 spawnAreaSize;    // Tamaño de la zona de spawn
    public float spawnInterval = 2f;  // Tiempo entre apariciones de esferas
    private float nextSpawnTime = 0f;

    void Update()
    {
        // Verifica si es el momento de generar una nueva esfera
        if (Time.time > nextSpawnTime)
        {
            SpawnSphere();
            nextSpawnTime = Time.time + spawnInterval;  // Ajusta el siguiente tiempo de spawn
        }
    }

    // Función para generar una esfera en una posición aleatoria dentro de la zona predefinida
    void SpawnSphere()
    {
        // Genera una posición aleatoria dentro de la zona de spawn
        float randomX = Random.Range(spawnAreaCenter.x - spawnAreaSize.x / 2, spawnAreaCenter.x + spawnAreaSize.x / 2);
        float randomY = Random.Range(spawnAreaCenter.y - spawnAreaSize.y / 2, spawnAreaCenter.y + spawnAreaSize.y / 2);
        float randomZ = Random.Range(spawnAreaCenter.z - spawnAreaSize.z / 2, spawnAreaCenter.z + spawnAreaSize.z / 2);

        Vector3 spawnPosition = new Vector3(randomX, randomY, randomZ);

        // Instancia la esfera en la posición generada
        GameObject sphere = Instantiate(spherePrefab, spawnPosition, Quaternion.identity);

        // Destruye la esfera después de 4 segundos
        Destroy(sphere, 4f);
    }
}
