using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereSpawner : MonoBehaviour
{
    
    public GameObject spherePrefab;  
    public Vector3 spawnAreaCenter; 
    public Vector3 spawnAreaSize;    
    public float spawnInterval = 2f;  
    private float nextSpawnTime = 0f;

    void Update()
    {
        
        if (Time.time > nextSpawnTime)
        {
            SpawnSphere();
            nextSpawnTime = Time.time + spawnInterval;  
        }
    }

    
    void SpawnSphere()
    {
        
        float randomX = Random.Range(spawnAreaCenter.x - spawnAreaSize.x / 2, spawnAreaCenter.x + spawnAreaSize.x / 2);
        float randomY = Random.Range(spawnAreaCenter.y - spawnAreaSize.y / 2, spawnAreaCenter.y + spawnAreaSize.y / 2);
        float randomZ = Random.Range(spawnAreaCenter.z - spawnAreaSize.z / 2, spawnAreaCenter.z + spawnAreaSize.z / 2);

        Vector3 spawnPosition = new Vector3(randomX, randomY, randomZ);

       
        GameObject sphere = Instantiate(spherePrefab, spawnPosition, Quaternion.identity);

       
        Destroy(sphere, 4f);
    }
}
