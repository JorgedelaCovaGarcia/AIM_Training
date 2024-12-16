using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    // Prefab del objeto a spawnear
    public GameObject objectPrefabs;

    // Intervalo de tiempo entre spawns
    public float spawnIntervals = 2f;

    // Distancia del movimiento en forma de Z
    public float movementDistance = 5f;

    // Velocidad del movimiento
    public float movementSpeeds = 2f;

    // Número de objetos a generar
    public int numberOfObjectss = 10;

    // Tiempo de vida de los objetos (en segundos)
    public float objectLifetimes = 2f;

    private void Start()
    {
        // Inicia el ciclo de generación
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        for (int i = 0; i < numberOfObjectss; i++)
        {
            // Generar el objeto
            GameObject spawnedObject = Instantiate(objectPrefabs, transform.position, Quaternion.identity);

            // Asignar el movimiento en Z
            StartCoroutine(MoveInZPattern(spawnedObject));

            // Destruir el objeto después de su tiempo de vida
            Destroy(spawnedObject, objectLifetimes);

            // Esperar antes de generar el siguiente objeto
            yield return new WaitForSeconds(spawnIntervals);
        }
    }

    private IEnumerator MoveInZPattern(GameObject obj)
    {
        // Variables de control para el movimiento
        Vector3 startPosition = obj.transform.position;
        Vector3 direction = new Vector3(1, 0, 1).normalized; // Primera diagonal (↗)
        float distanceTraveled = 0f;

        // Movimiento continuo en Z
        while (obj != null) // Asegurarse de que el objeto no fue destruido
        {
            // Calcular desplazamiento
            float step = movementSpeeds * Time.deltaTime;
            distanceTraveled += step;

            // Mover en la dirección actual
            obj.transform.position += direction * step;

            // Cambiar de dirección al alcanzar la distancia máxima
            if (distanceTraveled >= movementDistance)
            {
                direction = new Vector3(-direction.x, 0, direction.z * -1).normalized; // Cambiar de diagonal
                distanceTraveled = 0f; // Reiniciar el contador de distancia
            }

            yield return null;
        }
    }

    // Opcional: Dibujar la forma de la Z en la vista del editor
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;

        // Línea diagonal hacia arriba
        Vector3 startPoint = transform.position;
        Vector3 midPoint = startPoint + new Vector3(movementDistance, 0, movementDistance);
        Vector3 endPoint = midPoint + new Vector3(-movementDistance, 0, movementDistance);

        Gizmos.DrawLine(startPoint, midPoint);
        Gizmos.DrawLine(midPoint, endPoint);
    }
}


