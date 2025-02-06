using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsMenu : MonoBehaviour
{
    [SerializeField] public GameObject menuVolumen; // Arrastra aquí el Canvas del volumen
    [SerializeField] public GameObject menuInicial; // Arrastra aquí el Canvas del menú principal

    public void OpenSettings()
    {
        menuVolumen.SetActive(true);
        menuInicial.SetActive(false);
    }

    public void CloseSettings()
    {
        menuVolumen.SetActive(false);
        menuInicial.SetActive(true);
    }
}
