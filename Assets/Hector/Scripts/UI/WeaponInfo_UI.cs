using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using TMPro;
using UnityEngine;

public class WeaponInfo_UI : MonoBehaviour
{
    public TMP_Text currentBullets;
    public TMP_Text totalBullets;
     
    public void UpdateCurrent(int newCurrentBullets) 
    { 
        currentBullets.text = newCurrentBullets.ToString();
    
    }
   public void UpdateTotal (int newTotalBullets) 
    { 
     totalBullets.text = newTotalBullets.ToString();
    
    }
}
