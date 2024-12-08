using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public enum ShotType
    {
        Manual,
        Automatic
    }

    public WeaponController weapon;

    [Header("General")]
    public LayerMask hittableLayers;
    public GameObject bulletHolePrefab;
    private float lastTimeShoot = Mathf.NegativeInfinity;
    
    public int currentAmmo { get; private set; }

    [Header("Shoot Paramaters")]
    public float fireRange = 200;

    public float fireRate = 0.6f;
    public int maxAmmo = 8;
    private Transform cameraPlayerTransform;
    [Header("Reload Parameters")]
    public float reloadTime = 1.5f;

    private void Awake()
    {

        cameraPlayerTransform = GameObject.FindGameObjectWithTag("MainCamera").transform;
        currentAmmo = weapon.maxAmmo;
        EventManager.current.UpdateBulletsEvent.Invoke(currentAmmo, weapon.maxAmmo);
    }


    private void Start()
    {
        cameraPlayerTransform = GameObject.FindGameObjectWithTag("MainCamera").transform;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            TryShoot();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(Reload());
        }

        transform.localPosition = Vector3.Lerp(transform.localPosition, Vector3.zero, Time.deltaTime * 5f);
    }

    private void HandleShoot()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            RaycastHit hit;
            if (Physics.Raycast(cameraPlayerTransform.position, cameraPlayerTransform.forward, out hit, fireRange, hittableLayers))
            {
                GameObject bulletHoleClone = Instantiate(bulletHolePrefab, hit.point + hit.normal * 0.001f, Quaternion.LookRotation(hit.normal));
                Destroy(bulletHoleClone, 4f);
            }

        }
        lastTimeShoot = Time.time;

    }


    private bool TryShoot()
    {
        if (lastTimeShoot + fireRate < Time.time)
        {
            if (currentAmmo >= 1)
            {
                HandleShoot();
                currentAmmo -= 1;
                EventManager.current.UpdateBulletsEvent.Invoke(currentAmmo, maxAmmo);
                return true;

            }
        }

        return false;
    }
    IEnumerator Reload()
    {
        
        Debug.Log("Recargando...");
        yield return new WaitForSeconds(reloadTime);
        currentAmmo = maxAmmo;
        EventManager.current.UpdateBulletsEvent.Invoke(currentAmmo, maxAmmo);
        Debug.Log("Recargada");
        
    }




}
