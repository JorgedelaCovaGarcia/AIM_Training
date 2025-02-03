using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class VolumeController : MonoBehaviour
{
    public Scrollbar volumeScrollbar; // El Scrollbar que usaremos para ajustar el volumen
    public TextMeshProUGUI volumeText;           // El texto que mostrará el volumen actual
    public AudioSource audioSource;   // La fuente de audio cuyo volumen vamos a controlar

    void Start()
    {
        // Asegúrate de que el volumen inicial se ajuste al valor del Scrollbar
        volumeScrollbar.value = audioSource.volume; // El valor del Scrollbar será igual al volumen del audio (de 0 a 1)
        UpdateVolumeText(); // Actualiza el texto que muestra el volumen
    }

    // Método para actualizar el volumen según el valor del Scrollbar
    public void OnVolumeChanged()
    {
        audioSource.volume = volumeScrollbar.value; // Cambia el volumen de la fuente de audio
        UpdateVolumeText(); // Actualiza el texto del volumen
    }

    // Método para actualizar el texto con el volumen actual
    private void UpdateVolumeText()
    {
        if (volumeText != null)
        {
            volumeText.text = "Volumen: " + Mathf.RoundToInt(volumeScrollbar.value * 100) + "%";
        }
    }
}
