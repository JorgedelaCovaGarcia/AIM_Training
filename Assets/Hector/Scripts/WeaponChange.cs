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
