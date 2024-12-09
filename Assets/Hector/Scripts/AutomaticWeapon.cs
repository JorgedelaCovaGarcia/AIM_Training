using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomaticWeapon : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("General")]
    public LayerMask hittableLayers;  // Capa de objetos a los que se puede disparar
    public GameObject bulletHolePrefab;  // Prefab del agujero de bala
    private float lastTimeShoot = Mathf.NegativeInfinity;  // Para controlar el intervalo de disparo
    private Transform cameraPlayerTransform;

    [Header("Shoot Parameters")]
    public float fireRange = 200f;  // Rango de disparo
    public float fireRate = 0.1f;  // Intervalo entre disparos (m�s bajo para armas autom�ticas)
    public int maxAmmo = 30;  // M�ximo de balas en el cargador
    public int currentAmmo;  // Balas actuales en el cargador

    [Header("Reload Parameters")]
    public float reloadTime = 2f;  // Tiempo de recarga

    private bool isReloading = false;  // Para saber si el arma est� recargando

    private void Awake()
    {
        currentAmmo = maxAmmo;  // Al iniciar, el cargador est� lleno
    }

    private void Start()
    {
        // Obtener la referencia a la c�mara del jugador
        cameraPlayerTransform = GameObject.FindGameObjectWithTag("MainCamera").transform;
    }

    private void Update()
    {
        if (isReloading)
            return;  // Si est� recargando, no permitir disparar

        // Si se mantiene presionado el bot�n de disparo y hay munici�n, disparar
        if (Input.GetButton("Fire1") && currentAmmo > 0 && Time.time >= lastTimeShoot + fireRate)
        {
            lastTimeShoot = Time.time;  // Actualizamos el tiempo del �ltimo disparo
            HandleShoot();  // Llamamos a la funci�n que maneja el disparo
        }

        // Si el jugador presiona 'R', iniciar la recarga
        if (Input.GetKeyDown(KeyCode.R) || currentAmmo == 0)
        {
            StartCoroutine(Reload());  // Iniciar la recarga si se queda sin munici�n
        }
    }

    private void HandleShoot()
    {
        RaycastHit hit;
        // Disparamos un rayo en la direcci�n de la c�mara
        if (Physics.Raycast(cameraPlayerTransform.position, cameraPlayerTransform.forward, out hit, fireRange, hittableLayers))
        {
            // Instanciamos un agujero de bala en el lugar donde el rayo impacta
            GameObject bulletHoleClone = Instantiate(bulletHolePrefab, hit.point + hit.normal * 0.001f, Quaternion.LookRotation(hit.normal));
            Destroy(bulletHoleClone, 4f);  // Destruir el agujero de bala despu�s de 4 segundos
        }

        // Restar una bala del cargador
        currentAmmo--;

        // Si ya no hay munici�n, iniciar la recarga autom�ticamente
        if (currentAmmo == 0)
        {
            StartCoroutine(Reload());
        }
    }

    private IEnumerator Reload()
    {
        if (isReloading)
            yield break;  // Si ya est� recargando, no hacer nada m�s

        isReloading = true;
        Debug.Log("Recargando...");

        // TODO: Aqu� puedes agregar la animaci�n de recarga

        // Esperar el tiempo de recarga
        yield return new WaitForSeconds(reloadTime);

        // Recargar el cargador
        currentAmmo = maxAmmo;
        Debug.Log("Recargada");

        isReloading = false;
    }
}
