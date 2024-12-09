using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomaticWeapon : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("General")]
    public LayerMask hittableLayers;  
    public GameObject bulletHolePrefab;  
    private float lastTimeShoot = Mathf.NegativeInfinity;  
    private Transform cameraPlayerTransform;

    [Header("Shoot Parameters")]
    public float fireRange = 200f;  
    public float fireRate = 0.1f;  
    public int maxAmmo = 30;  
    public int currentAmmo;  

    [Header("Reload Parameters")]
    public float reloadTime = 2f;  

    private bool isReloading = false;  

    private void Awake()
    {
        currentAmmo = maxAmmo;  
    }

    private void Start()
    {
        
        cameraPlayerTransform = GameObject.FindGameObjectWithTag("MainCamera").transform;
    }

    private void Update()
    {
        if (isReloading)
            return;  

        
        if (Input.GetButton("Fire1") && currentAmmo > 0 && Time.time >= lastTimeShoot + fireRate)
        {
            lastTimeShoot = Time.time;  
            HandleShoot();  
        }

      
        if (Input.GetKeyDown(KeyCode.R) || currentAmmo == 0)
        {
            StartCoroutine(Reload());  
        }
    }

    private void HandleShoot()
    {
        RaycastHit hit;
        
        if (Physics.Raycast(cameraPlayerTransform.position, cameraPlayerTransform.forward, out hit, fireRange, hittableLayers))
        {
           
            GameObject bulletHoleClone = Instantiate(bulletHolePrefab, hit.point + hit.normal * 0.001f, Quaternion.LookRotation(hit.normal));
            Destroy(bulletHoleClone, 4f);  
        }

       
        currentAmmo--;

        
        if (currentAmmo == 0)
        {
            StartCoroutine(Reload());
        }
    }

    private IEnumerator Reload()
    {
        if (isReloading)
            yield break;  

        isReloading = true;
        Debug.Log("Recargando...");

       

       
        yield return new WaitForSeconds(reloadTime);

       
        currentAmmo = maxAmmo;
        Debug.Log("Recargada");

        isReloading = false;
    }
}
