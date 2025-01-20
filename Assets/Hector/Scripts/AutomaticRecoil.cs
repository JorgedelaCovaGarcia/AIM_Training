using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomaticRecoil : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Recoil Settings")]
    public float recoilAmountVertical = 0.3f;  
    public float recoilAmountHorizontal = 0.1f; 
    public float recoilSpeed = 10f;  
    public float returnSpeed = 5f;  

    [Header("Fire Settings")]
    public float fireRate = 0.1f;  
    public int maxAmmo = 30;  
    public int currentAmmo;  

    private float lastTimeShoot = Mathf.NegativeInfinity;  
    private Vector3 originalPosition;  
    private Vector3 currentRecoil;  

    private Transform cameraTransform;  

    void Start()
    {
        currentAmmo = maxAmmo;
        originalPosition = transform.localPosition;  
        cameraTransform = Camera.main.transform;  
    }

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= lastTimeShoot + fireRate && currentAmmo > 0)
        {
            lastTimeShoot = Time.time;
            HandleShoot();
        }

        if (currentAmmo == 0 || Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(Reload());  
        }

        
        ApplyRecoil();
    }

  
    void HandleShoot()
    {
      
        currentAmmo--;

        // Aquí puedes agregar la lógica de disparo, como raycast, creación de agujeros de bala, etc.

        // Aplicar el retroceso
        currentRecoil.y += recoilAmountVertical;  // Retroceso hacia arriba
        currentRecoil.x += Random.Range(-recoilAmountHorizontal, recoilAmountHorizontal);  // Retroceso aleatorio horizontal
    }

    // Método para aplicar el retroceso a la cámara
    void ApplyRecoil()
    {
        // Mover la cámara (o el arma) hacia arriba en función del retroceso
        cameraTransform.localPosition = Vector3.Lerp(cameraTransform.localPosition, originalPosition + currentRecoil, Time.deltaTime * recoilSpeed);

        // Reducir el retroceso gradualmente (simulando la recuperación)
        currentRecoil = Vector3.Lerp(currentRecoil, Vector3.zero, Time.deltaTime * returnSpeed);
    }

    // Coroutine para recargar el arma
    IEnumerator Reload()
    {
        // Aquí puedes incluir animaciones de recarga si lo deseas
        Debug.Log("Recargando...");
        yield return new WaitForSeconds(2f);  // Tiempo de recarga
        currentAmmo = maxAmmo;  // Recargar el arma
        Debug.Log("Recargada");
    }
}
