using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombieizqaderecha : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 2.0f;  // Velocidad del movimiento
    private float moveDirection = 1.0f; // Direcci�n del movimiento (1 = derecha, -1 = izquierda)

    public int health = 5;  // Salud inicial del zombie
    private bool isDead = false;  // Estado del zombie

    void Update()
    {
        if (isDead) return;  // Si el zombie est� muerto, no se mueve

        // Mueve al zombie en el eje X
        transform.Translate(Vector3.right * speed * moveDirection * Time.deltaTime);

        // Cambia de direcci�n al alcanzar l�mites
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

    // Funci�n para voltear el sprite en el eje X
    void Flip()
    {
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    // Funci�n para recibir da�o
    public void TakeDamage(int damage)
    {
        if (isDead) return;  // Si ya est� muerto, no recibe m�s da�o

        health -= damage;  // Reduce la salud por la cantidad de da�o recibido

        if (health <= 0)
        {
            Die();  // Si la salud llega a 0, el zombie muere
        }
    }

    // Funci�n que maneja la muerte del zombie
    void Die()
    {
        isDead = true;  // El zombie est� muerto
        // Puedes desactivar el zombie, destruirlo o cambiarlo de estado.
        // En este caso, lo destruimos despu�s de 1 segundo para simular que "muere"
        Destroy(gameObject, 1f);  // Destruye el zombie despu�s de 1 segundo
    }
}
