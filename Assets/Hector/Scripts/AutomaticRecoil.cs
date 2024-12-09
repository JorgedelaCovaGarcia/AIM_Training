using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomaticRecoil : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Recoil Settings")]
    public float recoilAmountVertical = 0.3f;  // Cuánto retrocede el arma verticalmente
    public float recoilAmountHorizontal = 0.1f; // Cuánto retrocede el arma horizontalmente
    public float recoilSpeed = 10f;  // Velocidad de movimiento del retroceso
    public float returnSpeed = 5f;  // Velocidad de retorno del arma a su posición original

    [Header("Fire Settings")]
    public float fireRate = 0.1f;  // Tiempo entre disparos
    public int maxAmmo = 30;  // Número máximo de balas
    public int currentAmmo;  // Número actual de balas

    private float lastTimeShoot = Mathf.NegativeInfinity;  // Tiempo del último disparo
    private Vector3 originalPosition;  // Posición original del arma
    private Vector3 currentRecoil;  // Variable que almacena el retroceso acumulado

    private Transform cameraTransform;  // Transform de la cámara para aplicar el retroceso

    void Start()
    {
        currentAmmo = maxAmmo;
        originalPosition = transform.localPosition;  // Guardar la posición original del arma
        cameraTransform = Camera.main.transform;  // Obtener la cámara principal del jugador
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
            StartCoroutine(Reload());  // Recargar si se presiona 'R' o si no hay más balas
        }

        // Aplicar retroceso a la cámara
        ApplyRecoil();
    }

    // Método para disparar y aplicar el retroceso
    void HandleShoot()
    {
        // Disparo: restamos una bala y aplicamos el retroceso
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
