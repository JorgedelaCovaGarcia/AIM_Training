using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sway : MonoBehaviour
{
    // Start is called before the first frame update
    private Quaternion originLocalRotation;
    private void Start()
    {
        originLocalRotation = transform.localRotation; 
    }

    // Update is called once per frame
    void Update()
    {
        updateSway();
    }
    void updateSway() 
    { 
        float t_xLookInput = Input.GetAxis("Mouse X");

        float t_yLookInput = Input.GetAxis("Mouse Y");
        Quaternion t_xAngleAdjustement = Quaternion.AngleAxis(-t_xLookInput*1.45f,Vector3.up);
        Quaternion t_yAngleAdjustement = Quaternion.AngleAxis(-t_yLookInput * 1.45f, Vector3.right);
        Quaternion t_targerRotation = originLocalRotation * t_xAngleAdjustement * t_yAngleAdjustement;
        transform.localRotation = Quaternion.Lerp(transform.localRotation,t_targerRotation, Time.deltaTime*10f);


    }

}

