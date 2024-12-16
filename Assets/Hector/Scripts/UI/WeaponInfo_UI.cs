using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using TMPro;
using UnityEngine;

public class WeaponInfo_UI : MonoBehaviour
{
    public TMP_Text currentBullets;
    public TMP_Text totalBullets;

    // Variables para gestionar las balas
    public int currentBulletCount = 30;  // Balas actuales
    public int totalBulletCount = 120;   // Total de balas (puede ser recargado)
    public int maxBulletsInClip = 30;    // M�ximo de balas en el cargador

    public float fireRate = 0.2f;  // Tasa de disparo
    private float nextFireTime = 0f;  // Controla cu�ndo se puede disparar nuevamente

    // Update es llamado una vez por frame
    void Update()
    {
        // Actualiza el HUD
        UpdateCurrent(currentBulletCount);
        UpdateTotal(totalBulletCount);

        // Comprobamos si el jugador presiona el bot�n de disparo (por ejemplo, bot�n izquierdo del rat�n)
        if (Input.GetButtonDown("Fire1") && Time.time >= nextFireTime)
        {
            Fire();
        }
    }

    // Funci�n para disparar
    void Fire()
    {
        if (currentBulletCount > 0)  // Aseg�rate de que haya balas en el cargador
        {
            // Disparar (puedes agregar m�s l�gica aqu�, como crear el disparo, efectos, etc.)
            Debug.Log("Disparo realizado");

            // Disminuir las balas actuales
            currentBulletCount--;

            // Actualizar el tiempo para el pr�ximo disparo (basado en fireRate)
            nextFireTime = Time.time + fireRate;
        }
        else
        {
            Debug.Log("No hay balas, recargando...");
            // Aqu� podr�as agregar la funci�n de recarga, por ejemplo
            Reload();
        }
    }

    // Funci�n para recargar
    void Reload()
    {
        if (totalBulletCount > 0)  // Si tienes balas disponibles para recargar
        {
            int bulletsNeeded = maxBulletsInClip - currentBulletCount;
            int bulletsToReload = Mathf.Min(bulletsNeeded, totalBulletCount);

            currentBulletCount += bulletsToReload;  // Recargar balas en el cargador
            totalBulletCount -= bulletsToReload;   // Disminuir las balas del total

            Debug.Log("Recargando...");
        }
        else
        {
            Debug.Log("No hay balas para recargar.");
        }
    }

    // M�todo para actualizar el n�mero de balas actuales en el HUD
    public void UpdateCurrent(int newCurrentBullets)
    {
        currentBullets.text = newCurrentBullets.ToString();
    }

    // M�todo para actualizar el n�mero de balas totales en el HUD
    public void UpdateTotal(int newTotalBullets)
    {
        totalBullets.text = newTotalBullets.ToString();
    }
}
