using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomaticRecoil : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Recoil Settings")]
    public float recoilAmountVertical = 0.3f;  // Cu�nto retrocede el arma verticalmente
    public float recoilAmountHorizontal = 0.1f; // Cu�nto retrocede el arma horizontalmente
    public float recoilSpeed = 10f;  // Velocidad de movimiento del retroceso
    public float returnSpeed = 5f;  // Velocidad de retorno del arma a su posici�n original

    [Header("Fire Settings")]
    public float fireRate = 0.1f;  // Tiempo entre disparos
    public int maxAmmo = 30;  // N�mero m�ximo de balas
    public int currentAmmo;  // N�mero actual de balas

    private float lastTimeShoot = Mathf.NegativeInfinity;  // Tiempo del �ltimo disparo
    private Vector3 originalPosition;  // Posici�n original del arma
    private Vector3 currentRecoil;  // Variable que almacena el retroceso acumulado

    private Transform cameraTransform;  // Transform de la c�mara para aplicar el retroceso

    void Start()
    {
        currentAmmo = maxAmmo;
        originalPosition = transform.localPosition;  // Guardar la posici�n original del arma
        cameraTransform = Camera.main.transform;  // Obtener la c�mara principal del jugador
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
            StartCoroutine(Reload());  // Recargar si se presiona 'R' o si no hay m�s balas
        }

        // Aplicar retroceso a la c�mara
        ApplyRecoil();
    }

    // M�todo para disparar y aplicar el retroceso
    void HandleShoot()
    {
        // Disparo: restamos una bala y aplicamos el retroceso
        currentAmmo--;

        // Aqu� puedes agregar la l�gica de disparo, como raycast, creaci�n de agujeros de bala, etc.

        // Aplicar el retroceso
        currentRecoil.y += recoilAmountVertical;  // Retroceso hacia arriba
        currentRecoil.x += Random.Range(-recoilAmountHorizontal, recoilAmountHorizontal);  // Retroceso aleatorio horizontal
    }

    // M�todo para aplicar el retroceso a la c�mara
    void ApplyRecoil()
    {
        // Mover la c�mara (o el arma) hacia arriba en funci�n del retroceso
        cameraTransform.localPosition = Vector3.Lerp(cameraTransform.localPosition, originalPosition + currentRecoil, Time.deltaTime * recoilSpeed);

        // Reducir el retroceso gradualmente (simulando la recuperaci�n)
        currentRecoil = Vector3.Lerp(currentRecoil, Vector3.zero, Time.deltaTime * returnSpeed);
    }

    // Coroutine para recargar el arma
    IEnumerator Reload()
    {
        // Aqu� puedes incluir animaciones de recarga si lo deseas
        Debug.Log("Recargando...");
        yield return new WaitForSeconds(2f);  // Tiempo de recarga
        currentAmmo = maxAmmo;  // Recargar el arma
        Debug.Log("Recargada");
    }
}
