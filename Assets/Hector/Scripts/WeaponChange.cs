using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponChange : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)|| Input.GetKeyDown(KeyCode.Keypad1)) 
        {
            CambiarArma(0);
    
        }
        if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1))
        {
            CambiarArma(1);

        }
    }
    private void CambiarArma(int indiceNuevaArma) 
    {
        armas[indiceArmaActual].SetActive(false);
       
        if(indiceNuevaArma < 0) 
        { 
            indiceNuevaArma = armas.Length -1;
      
        }
        else if(indiceNuevaArma > armas.Length) 
        {
            indiceNuevaArma = 0;
        
        }
        armas[indiceNuevaArma].SetActive(true);
        indiceArmaActual = indiceNuevaArma;
    }
    
}
