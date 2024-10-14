using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponController : MonoBehaviour
{
    public List <WeaponController> startingWeapons = new List<WeaponController>();
    public Transform weaponParentSocket;
    public Transform defaultWeaponPosition;
    public Transform aimingPosition;

    public int activeWeaponIndex { get; private set; }
    private WeaponController[] weaponSlots = new WeaponController[5]; 
    // Start is called before the first frame update
    void Start()
    {
        activeWeaponIndex = -1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void AddWeapon (WeaponController p_weaponPrefab) 
    { 
        weaponParentSocket.position = defaultWeaponPosition.position;

    
    
    }
}
