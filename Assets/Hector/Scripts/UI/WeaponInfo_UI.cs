using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using TMPro;
using UnityEngine;

public class WeaponInfo_UI : MonoBehaviour
{
    public TMP_Text currentBulletsText;  // Texto para mostrar las balas actuales
    public TMP_Text totalBulletsText;    // Texto para mostrar las balas totales
    public int currentBullets = 30;      // Balas actuales en el cargador
    public int totalBullets = 100;       // Total de balas en reserva

    public int maxCurrentBullets = 30;   // Máximo de balas en el cargador
    public int maxTotalBullets = 100;    // Máximo de balas en la reserva

    void Start()
    {
        // Actualizar los textos al inicio
        UpdateCurrentBullets(currentBullets);
        UpdateTotalBullets(totalBullets);
    }

    // Método para actualizar las balas actuales
    public void UpdateCurrentBullets(int currentBullets)
    {
        this.currentBullets = currentBullets;  // Actualizamos las balas actuales
        currentBulletsText.text = currentBullets.ToString(); // Actualizamos el texto
    }

    // Método para actualizar las balas totales
    public void UpdateTotalBullets(int totalBullets)
    {
        this.totalBullets = totalBullets;    // Actualizamos las balas totales
        totalBulletsText.text = totalBullets.ToString(); // Actualizamos el texto
    }

    // Método para disparar, reduce las balas actuales
    public void Disparar()
    {
        if (currentBullets > 0) // Solo dispara si hay balas disponibles
        {
            currentBullets--;
            UpdateCurrentBullets(currentBullets);  // Actualizamos las balas actuales

            // Lógica para disparar (suponiendo que ya tienes el código de disparo)
        }
        else
        {
            // Lógica para cuando no hay balas disponibles
            Debug.Log("No hay balas en el cargador");
        }
    }

    // Método para recargar, añade balas de la reserva al cargador
    public void Recargar()
    {
        int balasNecesarias = maxCurrentBullets - currentBullets;
        if (totalBullets > 0 && balasNecesarias > 0)
        {
            // Si hay balas en reserva, recargamos
            int balasRecargadas = Mathf.Min(balasNecesarias, totalBullets);
            currentBullets += balasRecargadas;
            totalBullets -= balasRecargadas;

            // Actualizamos el marcador
            UpdateCurrentBullets(currentBullets);
            UpdateTotalBullets(totalBullets);
        }
        else
        {
            Debug.Log("No hay balas suficientes en reserva para recargar.");
        }
    }
}
