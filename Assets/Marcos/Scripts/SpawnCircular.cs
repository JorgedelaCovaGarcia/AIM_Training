using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawners : MonoBehaviour
{
    // Prefab del objeto a spawnear
    public GameObject objectPrefab;

    // Intervalo de tiempo entre spawns
    public float spawnInterval = 2f;

    // Radio del patrón circular
    public float movementRadius = 5f;

    // Velocidad de rotación de los objetos
    public float movementSpeed = 2f;

    // Número de objetos a generar
    public int numberOfObjects = 10;

    // Tiempo de vida de los objetos (en segundos)
    public float objectLifetime = 2f;

    private void Start()
    {
        // Inicia el ciclo de generación
        StartCoroutine(SpawnObjects());
    }

    private IEnumerator SpawnObjects()
    {
        for (int i = 0; i < numberOfObjects; i++)
        {
            // Generar el objeto
            GameObject spawnedObject = Instantiate(objectPrefab, transform.position, Quaternion.identity);

            // Asignar el movimiento circular
            StartCoroutine(MoveInCircle(spawnedObject, i));

            // Destruir el objeto después de su tiempo de vida
            Destroy(spawnedObject, objectLifetime);

            // Esperar antes de generar el siguiente objeto
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private IEnumerator MoveInCircle(GameObject obj, int index)
    {
        float angle = 0;

        // Movimiento continuo en círculo
        while (obj != null) // Asegurarse de que el objeto no fue destruido
        {
            angle += movementSpeed * Time.deltaTime;

            // Calcular la posición en círculo
            float x = Mathf.Cos(angle + index) * movementRadius;
            float z = Mathf.Sin(angle + index) * movementRadius;

            // Actualizar la posición del objeto
            obj.transform.position = new Vector3(x, transform.position.y, z);

            yield return null;
        }
    }

    // Opcional: Dibujar el radio en la vista del editor
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, movementRadius);
    }
}


