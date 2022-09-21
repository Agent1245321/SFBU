using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CamScript : MonoBehaviour
{

    public Transform cam;
    public Transform pl1;
    public Transform pl2;
    private float avrx;
    private float z;

    void LateUpdate()
    {
        z = (float)((Math.Atan(avrx/5 / -20))*(180/3.14159));
        
        avrx = (pl1.transform.position.x + pl2.transform.position.x) / 2;

        if(Math.Abs(cam.transform.position.x) <= 19)
            {
            cam.transform.position = new Vector3(avrx + avrx/5, 3f, -20f);
            }
        if (cam.transform.position.x > 19)
        {
            cam.transform.position = new Vector3(19, 3f, -20f);
        }

        if (cam.transform.position.x < -19)
        {
            cam.transform.position = new Vector3(-19, 3f, -20f);
        }

       cam.rotation = Quaternion.Euler(0f, z, 0f);

       //Debug.Log(z);
    }
}
