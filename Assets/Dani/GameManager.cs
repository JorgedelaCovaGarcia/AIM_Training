using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject targetPrefab;
    public float spawnTime = 1f;
    public Vector3 screenBounds;
    public int score = 0;

    private void Start()
    {
        screenBounds = Camera.main.transform.position + new Vector3(Camera.main.orthographicSize * Camera.main.aspect, Camera.main.orthographicSize, 0);
        StartCoroutine(SpawnTargets());
    }

    private IEnumerator SpawnTargets()
    {
        while (true)
        {
            SpawnTarget();
            yield return new WaitForSeconds(spawnTime);
        }
    }

    private void SpawnTarget()
    {
        float spawnX = Random.Range(-screenBounds.x, screenBounds.x);
        float spawnY = Random.Range(-screenBounds.y, screenBounds.y);
        Vector3 spawnPosition = new Vector3(spawnX, spawnY, 0);
        Instantiate(targetPrefab, spawnPosition, Quaternion.identity);
    }

    public void IncreaseScore()
    {
        score++;
        Debug.Log("Puntuación: " + score);
    }
}
