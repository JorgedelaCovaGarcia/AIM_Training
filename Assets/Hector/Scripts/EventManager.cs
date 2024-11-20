using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class Int2Event : UnityEvent <int, int> { }
[SerializeField] 

public class EventManager : MonoBehaviour
{
    
    #region Signgleton
    public static EventManager current;
    private void Awake()
    {
        if(current == null) { current = this; }else if(current != null) { Destroy(this); }
    }
    #endregion
    
    public Int2Event updateBulletsEvent = new Int2Event(); 
}
