using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recoil : MonoBehaviour
{
    
    public Camera playerCamera; 
    public Transform weaponTransform; 

    public float recoilAmount = 0.1f; 
    public float recoilSpeed = 10f; 
    public float rotationAmount = 1f; 

    private Vector3 originalPosition;
    private Quaternion originalRotation;

    private void Start()
    {
       
        originalPosition = playerCamera.transform.localPosition;
        originalRotation = playerCamera.transform.localRotation;
    }

    void Update()
    {
       
        if (Input.GetMouseButtonDown(0)) 
        {
            ApplyRecoil();
        }

       
        ResetRecoil();
    }

    private void ApplyRecoil()
    {
        
        playerCamera.transform.localPosition -= new Vector3(0, 0, recoilAmount); 
        playerCamera.transform.localRotation *= Quaternion.Euler(Random.Range(-rotationAmount, rotationAmount), Random.Range(-rotationAmount, rotationAmount), 0);   
    }

    private void ResetRecoil()
    {
       
        playerCamera.transform.localPosition = Vector3.Lerp(playerCamera.transform.localPosition, originalPosition, Time.deltaTime * recoilSpeed);
        playerCamera.transform.localRotation = Quaternion.Lerp(playerCamera.transform.localRotation, originalRotation, Time.deltaTime * recoilSpeed);
    }
}
