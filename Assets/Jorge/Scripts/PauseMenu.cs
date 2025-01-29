using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PauseMenu : MonoBehaviour
{
    public GameObject ajustesUI; // Asigna el Panel de ajustes en el Inspector
    private bool juegoPausado = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (juegoPausado)
            {
                ReanudarJuego();
            }
            else
            {
                PausarJuego();
            }
        }
    }

    public void PausarJuego()
    {
        ajustesUI.SetActive(true);  // Mostrar menú
        Time.timeScale = 0f;        // Pausar el juego
        juegoPausado = true;
    }

    public void ReanudarJuego()
    {
        ajustesUI.SetActive(false); // Ocultar menú
        Time.timeScale = 1f;        // Reanudar el juego
        juegoPausado = false;
    }
}
