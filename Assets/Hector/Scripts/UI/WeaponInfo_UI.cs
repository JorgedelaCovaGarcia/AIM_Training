using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using TMPro;
using UnityEngine;

public class WeaponInfo_UI : MonoBehaviour
{
    public TMP_Text currentBulletsText;  // Muestra las balas actuales
    public TMP_Text totalBulletsText;    // Muestra las balas totales

    // Método para actualizar las balas actuales en la UI
    public void UpdateCurrentBullets(int currentBullets)
    {
        currentBulletsText.text = currentBullets.ToString();
    }

    // Método para actualizar las balas totales en la UI
    public void UpdateTotalBullets(int totalBullets)
    {
        totalBulletsText.text = totalBullets.ToString();
    }
}
