using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorDeEnemigos : MonoBehaviour
{
    public GameObject enemyPrefab;  
    public GameObject spawnArea;    

    public float spawnInterval = 2f;  
    public int maxEnemies = 10;    

    private int currentEnemyCount = 0; 
    private List<Vector3> spawnPoints = new List<Vector3>(); 

    void Start()
    {
       
        GenerateSpawnPoints();

        
        StartCoroutine(SpawnEnemies());
    }

    private void GenerateSpawnPoints()
    {
        
        Vector3 spawnAreaSize = spawnArea.GetComponent<Renderer>().bounds.size;
        Vector3 spawnAreaCenter = spawnArea.transform.position;

        // Generar varios puntos dentro del área del cubo
        for (int i = 0; i < 5; i++)  // Ejemplo: Generamos 5 puntos de spawn
        {
            // Calcula una posición aleatoria dentro de las dimensiones del cubo
            float xPos = Random.Range(spawnAreaCenter.x - spawnAreaSize.x / 2, spawnAreaCenter.x + spawnAreaSize.x / 2);
            float yPos = Random.Range(spawnAreaCenter.y - spawnAreaSize.y / 2, spawnAreaCenter.y + spawnAreaSize.y / 2);
            float zPos = Random.Range(spawnAreaCenter.z - spawnAreaSize.z / 2, spawnAreaCenter.z + spawnAreaSize.z / 2);

            // Agrega el punto de spawn a la lista
            spawnPoints.Add(new Vector3(xPos, yPos, zPos));
        }
    }

    private IEnumerator SpawnEnemies()
    {
        while (currentEnemyCount < maxEnemies)
        {
           
            yield return new WaitForSeconds(spawnInterval);

            
            Vector3 spawnPosition = spawnPoints[Random.Range(0, spawnPoints.Count)];

          
            Instantiate(enemyPrefab, spawnPosition, Quaternion.Euler(0, -90, 0));

            // Incrementa el contador de enemigos
            currentEnemyCount++;
        }
    }
}
