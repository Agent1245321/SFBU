using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pl1Fight : MonoBehaviour
{
    public static float pl1Perc;
    private float pl1Meter = 0;
    public static bool hitStun;
    public Transform upperCut;
    public Transform pl1;
    public GameObject uppercutCol;
    public ParticleSystem uppercutParticals;
    public Rigidbody pl1RB;
    private float horizontalInput;
    private bool meterLock;
    public bool iFrames1;
    public Material red;
    public Material dred;

    private void Start()
    {
     
        StartCoroutine(MeterBurn());
    }


    IEnumerator MeterBurn()
    {
        
        while (pl1Meter < 100)
        {
            yield return new WaitForSeconds(.5f);
            pl1Meter += 5;
        }

        meterLock = true;

        yield return null;

        
    }

    [System.Obsolete]
    public void Update()
    {
        // uppercut start

        if (Input.GetButtonDown("Joystick1-1") && hitStun == false)
        {
            StartCoroutine(UpperCut());
        }
        if (pl1Meter < 100 && meterLock == true)
        {
            meterLock = false;
            StartCoroutine(MeterBurn());
        }

        if(Input.GetAxis("Joystick1Horizontal2") > .8f)
        {
            horizontalInput = 1;
        }

        if (Input.GetAxis("Joystick1Horizontal2") < -0.8f)
        {
            horizontalInput = -1;

        }
    }

    private void FixedUpdate()
    {
       
    }

    [System.Obsolete]
    IEnumerator UpperCut()
    {
        if (pl1Meter >= 25)
        {
            pl1Meter -= 25f;
            uppercutCol.SetActive(true);
            upperCut.position = new Vector3(pl1.transform.position.x + horizontalInput * .8f, pl1.transform.position.y - .75f, 0f);
            yield return new WaitForSeconds(.02f);
            uppercutParticals.enableEmission = true;

            upperCut.position = new Vector3(pl1.transform.position.x + horizontalInput * 1f, pl1.transform.position.y - .5f, 0f);
            yield return new WaitForSeconds(.02f);

            upperCut.position = new Vector3(pl1.transform.position.x + horizontalInput * 1.1f, pl1.transform.position.y - .25f, 0f);
            yield return new WaitForSeconds(.02f);          

            upperCut.position = new Vector3(pl1.transform.position.x + horizontalInput * 1.2f, pl1.transform.position.y, 0f);
            yield return new WaitForSeconds(.02f);

            upperCut.position = new Vector3(pl1.transform.position.x + horizontalInput * 1.3f, pl1.transform.position.y + .25f, 0f);
            yield return new WaitForSeconds(.02f);

            upperCut.position = new Vector3(pl1.transform.position.x + horizontalInput * 1.3f, pl1.transform.position.y + .5f, 0f);
            yield return new WaitForSeconds(.02f);

            upperCut.position = new Vector3(pl1.transform.position.x + horizontalInput * 1.2f, pl1.transform.position.y + .75f, 0f);
            yield return new WaitForSeconds(.02f);
            
            uppercutParticals.enableEmission = false;
            uppercutCol.SetActive(false);


            yield return null;
        }
    }
    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.name == "Sphere" && hitStun == false)
        {
            StartCoroutine(HitStun());
            //pl1RB.AddForce(pl1Perc / 5f, pl1Perc, 0);
            pl1Perc += 800f;

        }
    }



    IEnumerator HitStun()
    {
        hitStun = true;
        red.color = Color.black;
        yield return new WaitForSeconds(Mathf.Pow(pl1Perc, 1.2f) / 10000f);
        hitStun = false;
        red.color = Color.red;

        yield return null;
    }

}
