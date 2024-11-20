using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using TMPro;
using UnityEngine;

public class WeaponInfo_UI : MonoBehaviour
{
    public TMP_Text currentBullets;
    public TMP_Text totalBullets;
    private void OnDisable()
    {
        EventManager.current.updateBulletsEvent.AddListener(UpdateBullets); 
    }
   private void OnEnable()
    {
        EventManager.current.updateBulletsEvent.AddListener(UpdateBullets);
    }

    public void UpdateBullets(int newCurrentBullets,int newTotalBullets) 
    { 
        currentBullets.text = newCurrentBullets.ToString();
        totalBullets.text = newTotalBullets.ToString();
    }
   
}

