using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerNinjaFruit : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject bolaPrefab;  // Prefab de la bola
    public float intervaloSpawn = 2f;  // Intervalo entre la aparición de las bolas
    public float impulso = 10f;  // Fuerza del impulso hacia arriba
    public BoxCollider spawnArea;  // Collider del área de spawn

    // Start is called before the first frame update
    void Start()
    {
        // Llamar a la función para spawnear bolas en intervalos
        StartCoroutine(SpawnBolas());
    }

    IEnumerator SpawnBolas()
    {
        while (true)
        {
            // Generar una nueva bola dentro del área de spawn
            Vector3 spawnPosition = new Vector3(
                Random.Range(spawnArea.bounds.min.x, spawnArea.bounds.max.x),
                spawnArea.transform.position.y + 0.5f,  // La altura del suelo más un poco de espacio
                Random.Range(spawnArea.bounds.min.z, spawnArea.bounds.max.z)
            );

            GameObject bola = Instantiate(bolaPrefab, spawnPosition, Quaternion.identity);

            // Agregar un impulso hacia arriba
            Rigidbody rb = bola.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddForce(Vector3.up * impulso, ForceMode.Impulse);
            }

            // Esperar antes de crear la siguiente bola
            yield return new WaitForSeconds(intervaloSpawn);
        }
    }
}
