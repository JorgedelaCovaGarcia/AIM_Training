using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponChange : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] armas; 
    private int indiceArmaActual = 0;  

    void Start()
    {
        if (armas.Length > 0)
        {
            armas[indiceArmaActual].SetActive(true);  
        }
    }

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1))
        {
            CambiarArma(0);
        }

      
        if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2))
        {
            CambiarArma(1);
        }

      
        if (Input.GetKeyDown(KeyCode.Q))  
        {
            CambiarArmaSiguiente();
        }

      
        if (Input.GetKeyDown(KeyCode.E))  
        {
            CambiarArmaAnterior();
        }
    }

    private void CambiarArma(int indiceNuevaArma)
    {
        if (armas.Length == 0) return;  

        
        armas[indiceArmaActual].SetActive(false);

       
        if (indiceNuevaArma < 0)
        {
            indiceNuevaArma = armas.Length - 1;  
        }
        else if (indiceNuevaArma >= armas.Length)
        {
            indiceNuevaArma = 0;  
        }

       
        armas[indiceNuevaArma].SetActive(true);
        indiceArmaActual = indiceNuevaArma;  
    }

    private void CambiarArmaSiguiente()
    {
        
        int siguienteArma = (indiceArmaActual + 1) % armas.Length;  
        CambiarArma(siguienteArma);
    }

    private void CambiarArmaAnterior()
    {
      
        int armaAnterior = (indiceArmaActual - 1 + armas.Length) % armas.Length;  
        CambiarArma(armaAnterior);
    }
}
