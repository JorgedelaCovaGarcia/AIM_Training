using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recoil : MonoBehaviour
{
    // Start is called before the first frame update
    public float recoilAmount = 0.2f; 
    public float recoilSpeed = 5f; 
    public float returnSpeed = 10f; 

    private Vector3 originalPosition; 
    private Vector3 currentRecoil; 

    void Start()
    {
      
        originalPosition = transform.localPosition;
    }

    void Update()
    {
       
        if (Input.GetButtonDown("Fire1")) 
        {
            ApplyRecoil();
        }

        
        currentRecoil = Vector3.Lerp(currentRecoil, Vector3.zero, returnSpeed * Time.deltaTime);
        transform.localPosition = originalPosition + currentRecoil;
    }

    void ApplyRecoil()
    {

        transform.Rotate(-recoilAmount * 5, 0, 0);
        currentRecoil += new Vector3(0f, 0f, -recoilAmount); 
    }
}
