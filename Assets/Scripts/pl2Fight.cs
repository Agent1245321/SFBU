using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class pl2Fight : MonoBehaviour
{

    public static float pl2Perc;
    private float pl2Meter = 0;
    public static bool hitStun;
    public Transform upperCut2;
    public Transform pl2;
    public GameObject uppercutCol2;
    public ParticleSystem uppercutParticles2;
    public Rigidbody pl2RB;
    private float horizontalInput;
    private bool meterLock;
    public bool iFrames2;
    private void Start()
    {
        StartCoroutine(MeterBurn());
    }


    IEnumerator MeterBurn()
    {

        while (pl2Meter < 100)
        {
            yield return new WaitForSeconds(.5f);
            pl2Meter += 5;
        }

        meterLock = true;

        yield return null;



    }

    [System.Obsolete]
    public void Update()
    {
        if (Input.GetButtonDown("Joystick2-1") && hitStun == false)
        {
         
            StartCoroutine(UpperCut2());
        }
        if (pl2Meter < 100 && meterLock == true)
        {
            meterLock = false;
            StartCoroutine(MeterBurn());
        }

        if (Input.GetAxis("Joystick2Horizontal2") > .8f)
        {
            horizontalInput = 1;
        }

        if (Input.GetAxis("Joystick2Horizontal2") < -0.8f)
        {
            horizontalInput = -1;
        }
        //Debug.Log(pl2Meter);
    }

    private void FixedUpdate()
    {
        // Debug.Log(pl2Meter);
    }

    [System.Obsolete]
    IEnumerator UpperCut2()
    {
        if (pl2Meter >= 25f)
        {
            pl2Meter -= 25f;
            uppercutCol2.SetActive(true);
            upperCut2.position = new Vector3(pl2.transform.position.x + horizontalInput * .8f, pl2.transform.position.y - .75f, 0f);
            yield return new WaitForSeconds(.02f);
            uppercutParticles2.enableEmission = true;

            upperCut2.position = new Vector3(pl2.transform.position.x + horizontalInput * 1f, pl2.transform.position.y - .5f, 0f);
            yield return new WaitForSeconds(.02f);

            upperCut2.position = new Vector3(pl2.transform.position.x + horizontalInput * 1.1f, pl2.transform.position.y - .25f, 0f);
            yield return new WaitForSeconds(.02f);

            upperCut2.position = new Vector3(pl2.transform.position.x + horizontalInput * 1.2f, pl2.transform.position.y, 0f);
            yield return new WaitForSeconds(.02f);

            upperCut2.position = new Vector3(pl2.transform.position.x + horizontalInput * 1.3f, pl2.transform.position.y + .25f, 0f);
            yield return new WaitForSeconds(.02f);

            upperCut2.position = new Vector3(pl2.transform.position.x + horizontalInput * 1.3f, pl2.transform.position.y + .5f, 0f);
            yield return new WaitForSeconds(.02f);

            upperCut2.position = new Vector3(pl2.transform.position.x + horizontalInput * 1.2f, pl2.transform.position.y + .75f, 0f);
            yield return new WaitForSeconds(.02f);
            
            uppercutParticles2.enableEmission = false;
            uppercutCol2.SetActive(false);
            

            yield return null;
        }
    }

    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.name == "Sphere" && hitStun == false)
        {
            
            
                Debug.Log(Mathf.Pow(pl2Perc, 1.2f) / 10000f);
                StartCoroutine(HitStun());
                pl2RB.AddForce(pl2Perc / 5f, pl2Perc, 0);
                pl2Perc += 800f;
            
            
        }
    }

    IEnumerator HitStun()
    {
        hitStun = true;
        yield return new WaitForSeconds(Mathf.Pow(pl2Perc,1.2f) / 10000f);
        hitStun = false;

        yield return null;
    }

}

