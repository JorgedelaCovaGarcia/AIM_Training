using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoBala : MonoBehaviour
{
    public GameObject balaPrefab;    // Prefab de la bala
    public Transform puntoDeDisparo; // Punto desde donde se dispara la bala
    public float fuerzaDisparo = 500f; // Fuerza de disparo

    void Update()
    {
        // Detectar cuando el jugador presiona la tecla para disparar
        if (Input.GetKeyDown(KeyCode.Space)) // Puedes cambiar Space por otra tecla
        {
            Disparar();
        }
    }

    void Disparar()
    {
        // Crear la bala en el punto de disparo
        GameObject bala = Instantiate(balaPrefab, puntoDeDisparo.position, puntoDeDisparo.rotation);

        // Obtener el Rigidbody de la bala
        Rigidbody rb = bala.GetComponent<Rigidbody>();
        if (rb != null)
        {
            // Aplicar fuerza para disparar la bala hacia adelante
            rb.AddForce(puntoDeDisparo.forward * fuerzaDisparo);
        }
    }
}

