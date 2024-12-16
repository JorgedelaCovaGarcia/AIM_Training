using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawners : MonoBehaviour
{
    // Prefab del objeto a spawnear
    public GameObject objectPrefab;

    // Intervalo de tiempo entre spawns
    public float spawnInterval = 2f;

    // Radio del patr�n circular
    public float movementRadius = 5f;

    // Velocidad de rotaci�n de los objetos
    public float movementSpeed = 2f;

    // N�mero de objetos a generar
    public int numberOfObjects = 10;

    // Tiempo de vida de los objetos (en segundos)
    public float objectLifetime = 2f;

    private void Start()
    {
        // Inicia el ciclo de generaci�n
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

            // Destruir el objeto despu�s de su tiempo de vida
            Destroy(spawnedObject, objectLifetime);

            // Esperar antes de generar el siguiente objeto
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private IEnumerator MoveInCircle(GameObject obj, int index)
    {
        float angle = 0;

        // Movimiento continuo en c�rculo
        while (obj != null) // Asegurarse de que el objeto no fue destruido
        {
            angle += movementSpeed * Time.deltaTime;

            // Calcular la posici�n en c�rculo
            float x = Mathf.Cos(angle + index) * movementRadius;
            float z = Mathf.Sin(angle + index) * movementRadius;

            // Actualizar la posici�n del objeto
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


