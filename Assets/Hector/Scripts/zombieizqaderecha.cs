using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombieizqaderecha : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 2.0f;  // Velocidad del movimiento
    private float moveDirection = 1.0f; // Dirección del movimiento (1 = derecha, -1 = izquierda)

    public int health = 5;  // Salud inicial del zombie
    private bool isDead = false;  // Estado del zombie

    void Update()
    {
        if (isDead) return;  // Si el zombie está muerto, no se mueve

        // Mueve al zombie en el eje X
        transform.Translate(Vector3.right * speed * moveDirection * Time.deltaTime);

        // Cambia de dirección al alcanzar límites
        if (transform.position.x > 10f) // Limite derecho
        {
            moveDirection = -1f; // Mover hacia la izquierda
            Flip(); // Hacer que el zombie mire a la izquierda
        }
        else if (transform.position.x < -10f) // Limite izquierdo
        {
            moveDirection = 1f; // Mover hacia la derecha
            Flip(); // Hacer que el zombie mire a la derecha
        }
    }

    // Función para voltear el sprite en el eje X
    void Flip()
    {
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    // Función para recibir daño
    public void TakeDamage(int damage)
    {
        if (isDead) return;  // Si ya está muerto, no recibe más daño

        health -= damage;  // Reduce la salud por la cantidad de daño recibido

        if (health <= 0)
        {
            Die();  // Si la salud llega a 0, el zombie muere
        }
    }

    // Función que maneja la muerte del zombie
    void Die()
    {
        isDead = true;  // El zombie está muerto
        // Puedes desactivar el zombie, destruirlo o cambiarlo de estado.
        // En este caso, lo destruimos después de 1 segundo para simular que "muere"
        Destroy(gameObject, 1f);  // Destruye el zombie después de 1 segundo
    }
}
