using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponControllerAutomatic : MonoBehaviour
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

    [Header("Recoil Parameters")]
    public float recoilForceX = 2f;  // Fuerza del retroceso en el eje X (vertical)
    public float recoilForceY = 0.5f;  // Fuerza del retroceso en el eje Y (horizontal)
    public float recoilRecoverySpeed = 5f;  // Velocidad de recuperación del retroceso

    private Vector3 currentRecoil = Vector3.zero;
    private Vector3 targetRecoil = Vector3.zero;

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

        // Disparo automático si se mantiene presionado
        if (Input.GetButton("Fire1") && currentAmmo > 0 && Time.time >= lastTimeShoot + fireRate)
        {
            lastTimeShoot = Time.time;
            HandleShoot();
        }

        // Recarga
        if (Input.GetKeyDown(KeyCode.R) || currentAmmo == 0)
        {
            StartCoroutine(Reload());
        }

        // Recuperar el recoil de manera suave
        RecoverRecoil();
    }

    private void HandleShoot()
    {
        RaycastHit hit;

        // Raycast para simular el disparo
        if (Physics.Raycast(cameraPlayerTransform.position, cameraPlayerTransform.forward, out hit, fireRange, hittableLayers))
        {
            // Generar agujero de bala en la superficie impactada
            GameObject bulletHoleClone = Instantiate(bulletHolePrefab, hit.point + hit.normal * 0.001f, Quaternion.LookRotation(hit.normal));
            Destroy(bulletHoleClone, 4f);
        }

        // Disminuir las balas
        currentAmmo--;

        // Aplicar recoil
        ApplyRecoil();

        // Si se quedan sin balas, recargar
        if (currentAmmo == 0)
        {
            StartCoroutine(Reload());
        }
    }

    private void ApplyRecoil()
    {
        // Recoil en el eje X (horizontal)
        targetRecoil.x = Random.Range(-recoilForceY, recoilForceY);  // Recoil horizontal (izquierda/derecha)
        // Recoil en el eje Y (vertical)
        targetRecoil.y = recoilForceX;  // Recoil vertical (arriba)

        // Asegurarnos de que el recoil no sea demasiado grande
        targetRecoil.x = Mathf.Clamp(targetRecoil.x, -recoilForceY, recoilForceY);
        targetRecoil.y = Mathf.Clamp(targetRecoil.y, 0f, recoilForceX);
    }

    private void RecoverRecoil()
    {
        // Suavizar el recoil usando Lerp
        currentRecoil = Vector3.Lerp(currentRecoil, targetRecoil, Time.deltaTime * recoilRecoverySpeed);

        // Aplicar el recoil a la cámara de forma controlada en su espacio local
        cameraPlayerTransform.localPosition = new Vector3(0, -currentRecoil.y, -currentRecoil.x);
    }

    private IEnumerator Reload()
    {
        if (isReloading)
            yield break;

        isReloading = true;
        Debug.Log("Recargando...");

        // Simulación de tiempo de recarga
        yield return new WaitForSeconds(reloadTime);

        // Recargar balas
        currentAmmo = maxAmmo;
        Debug.Log("Recargada");

        isReloading = false;
    }
}
