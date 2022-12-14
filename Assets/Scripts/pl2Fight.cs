using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class pl2Fight : MonoBehaviour
{

    public static float pl2Perc;

    public static float pl2Meter = 0;
    public static bool hitStun;
    public Transform pl2;
    public Rigidbody pl2RB;
    public static float horizontalInput;
    private bool meterLock;
    public bool iFrames2;

    public MeshRenderer pl2MeshRender;
    public Material lpurple;
    public Material purple;



    //uppercut
    public Transform upperCut2;
    public GameObject uppercutCol2;
    public ParticleSystem uppercutParticles2;
    public Transform uppt;


    //gentelmen
    public Transform gentelmen1T;
    public GameObject gentelmen1O;
    public Transform gentelmen2T;
    public GameObject gentelmen2O;
    public Transform gentelmen3T;
    public GameObject gentelmen3O;
    public int gstage;
    private bool g2active;
    private bool g3active;
    private float bonusHitstun2;
    private float hitStunMultiplier2;


    public static bool pl1Gm1HS;
    public static bool pl1Gm2HS;
    public static bool pl1Gm3HS;

    //spikey
        public GameObject urMom2;

    private void Start()
    {
        StartCoroutine(MeterBurn());
        gstage = 0;
    }


    IEnumerator MeterBurn()
    {

        while (pl2Meter < 100)
        {
            yield return new WaitForSeconds(.5f);
            pl2Meter += 2;
            if(Input.GetKey("p"))
            {
                pl2Meter += 30;
            }
        }

        meterLock = true;

        yield return null;



    }

    [System.Obsolete]
    public void Update()

    {
        if(Input.GetKeyDown("o"))
        {
            pl2Perc = 5000f;
            pl1Fight.pl1Perc = 5000f;
        }
        //Debug.Log(pl1Gm1HS);
        if (Input.GetButtonDown("Joystick2-1") && hitStun == false && Mathf.Abs(Input.GetAxis("Joystick2Horizontal2")) > .8f)
            
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

        if(Input.GetButtonDown("Joystick2-0") && hitStun == false)
        {
            
            
            if (gstage == 0)
            {
                StartCoroutine(Gentelmen1());
            }
            gstage += 1;
        }

        if (Input.GetButtonDown("Joystick2-1") && hitStun == false && Input.GetAxis("Joystick2Vertical2") < -.8f && pl2Meter >= 75)
        {
            Debug.Log("Called");
            StartCoroutine(Spikey2());
        }
    }

    private void FixedUpdate()
    {
        
    }

    [System.Obsolete]
    IEnumerator UpperCut2()
    {
        if (pl2Meter >= 50f)
        {
            pl2Meter -= 50f;
            uppercutCol2.SetActive(true);
            upperCut2.position = new Vector3(pl2.transform.position.x + horizontalInput * .8f, pl2.transform.position.y - .75f, 0f);
            uppt.transform.position = upperCut2.transform.position;
            yield return new WaitForSeconds(.02f);
            uppercutParticles2.enableEmission = true;

            upperCut2.position = new Vector3(pl2.transform.position.x + horizontalInput * 1f, pl2.transform.position.y - .5f, 0f);
            uppt.transform.position = upperCut2.transform.position;
            yield return new WaitForSeconds(.02f);

            upperCut2.position = new Vector3(pl2.transform.position.x + horizontalInput * 1.1f, pl2.transform.position.y - .25f, 0f);
            uppt.transform.position = upperCut2.transform.position;
            yield return new WaitForSeconds(.02f);

            upperCut2.position = new Vector3(pl2.transform.position.x + horizontalInput * 1.3f, pl2.transform.position.y, 0f);
            uppt.transform.position = upperCut2.transform.position;
            yield return new WaitForSeconds(.02f);

            upperCut2.position = new Vector3(pl2.transform.position.x + horizontalInput * 1.5f, pl2.transform.position.y + .25f, 0f);
            uppt.transform.position = upperCut2.transform.position;
            yield return new WaitForSeconds(.02f);

            upperCut2.position = new Vector3(pl2.transform.position.x + horizontalInput * 1.7f, pl2.transform.position.y + .5f, 0f);
            uppt.transform.position = upperCut2.transform.position;
            yield return new WaitForSeconds(.02f);

            upperCut2.position = new Vector3(pl2.transform.position.x + horizontalInput * 1.5f, pl2.transform.position.y + .75f, 0f);
            uppt.transform.position = upperCut2.transform.position;
            yield return new WaitForSeconds(.02f);
            
            uppercutParticles2.enableEmission = false;
            uppercutCol2.SetActive(false);
            

            yield return null;
        }
    }




    IEnumerator Gentelmen1()
    {
        yield return new WaitForSeconds(.2f);
        
        gentelmen1T.position = new Vector3(pl2.position.x + horizontalInput * .8f, pl2.position.y + -.5f ,0f);
        gentelmen1O.SetActive(true);
        gentelmen1T.position = new Vector3(pl2.position.x + horizontalInput * 1.2f, pl2.position.y + -.4f, 0f);
        yield return new WaitForSeconds(.02f);

        if (gstage >= 2 && g2active == false)
        {
            StartCoroutine(Gentelmen2());
        }

        gentelmen1T.position = new Vector3(pl2.position.x + horizontalInput * 1.8f, pl2.position.y + -.3f, 0f);
        yield return new WaitForSeconds(.02f);

        if (gstage >= 2 && g2active == false)
        {
            StartCoroutine(Gentelmen2());
        }

        gentelmen1T.position = new Vector3(pl2.position.x + horizontalInput * 2.6f, pl2.position.y + .1f, 0f);
        yield return new WaitForSeconds(.02f);

        if(gstage >= 2)
        {
            StartCoroutine(Gentelmen2());
        }

        gentelmen1T.position = new Vector3(pl2.position.x + horizontalInput * 2.7f, pl2.position.y + .5f, 0f);
        yield return new WaitForSeconds(.02f);

        if (gstage >= 2 && g2active == false)
        {
            StartCoroutine(Gentelmen2());
        }

        gentelmen1T.position = new Vector3(pl2.position.x + horizontalInput * 2.7f, pl2.position.y + 1f, 0f);
        gentelmen1O.SetActive(false);

        

        if (gstage >= 2 && g2active == false)
        {
            StartCoroutine(Gentelmen2());
        }

        yield return new WaitForSeconds(.5f);


        if (g2active == false)
        {
            yield return new WaitForSeconds(.5f);
            gstage = 0;
        }
        pl1Gm1HS = false;
        yield return null;
    }

    IEnumerator Gentelmen2()
    {
        g2active = true;
        yield return new WaitForSeconds(.1f);
        
        gentelmen2T.position = new Vector3(pl2.position.x + horizontalInput * .8f, pl2.position.y + .8f, 0f);
        gentelmen2O.SetActive(true);
        gentelmen2T.position = new Vector3(pl2.position.x + horizontalInput * 1.2f, pl2.position.y + .7f, 0f);
        yield return new WaitForSeconds(.02f);

        if (gstage >= 3 && g3active == false)
        {
            StartCoroutine(Gentelmen3());
        }

        gentelmen2T.position = new Vector3(pl2.position.x + horizontalInput * 1.8f, pl2.position.y + .6f, 0f);
        yield return new WaitForSeconds(.02f);

        if (gstage >= 3 && g3active == false)
        {
            StartCoroutine(Gentelmen3());
        }

        gentelmen2T.position = new Vector3(pl2.position.x + horizontalInput * 2.6f, pl2.position.y + .3f, 0f);
        yield return new WaitForSeconds(.02f);

        if (gstage >= 3 && g3active == false)
        {
            StartCoroutine(Gentelmen3());
        }

        gentelmen2T.position = new Vector3(pl2.position.x + horizontalInput * 2.7f, pl2.position.y + -.1f, 0f);
        yield return new WaitForSeconds(.02f);

        if (gstage >= 3 && g3active == false)
        {
            StartCoroutine(Gentelmen3());
        }

        gentelmen2T.position = new Vector3(pl2.position.x + horizontalInput * 2.7f, pl2.position.y + -.6f, 0f);
        gentelmen2O.SetActive(false);

        if (gstage >= 3 && g3active == false)
        {
            StartCoroutine(Gentelmen3());
        }

        yield return new WaitForSeconds(.5f);

        if (g3active == false)
        {
            yield return new WaitForSeconds(.5f);
            gstage = 0;
        }

        g2active = false;
        pl1Gm2HS = false;
        yield return null;
    }

    IEnumerator Gentelmen3()
    {
        g3active = true;
        yield return new WaitForSeconds(.1f);
        
        gentelmen3T.position = new Vector3(pl2.position.x + horizontalInput * .5f, pl2.position.y, 0f);
        gentelmen3O.SetActive(true);
        gentelmen3T.position = new Vector3(pl2.position.x + horizontalInput * .9f, pl2.position.y, 0f);
        yield return new WaitForSeconds(.02f);
        gentelmen3T.position = new Vector3(pl2.position.x + horizontalInput * 1.4f, pl2.position.y, 0f);
        yield return new WaitForSeconds(.02f);
        gentelmen3T.position = new Vector3(pl2.position.x + horizontalInput * 2f, pl2.position.y, 0f);
        yield return new WaitForSeconds(.02f);
        gentelmen3T.position = new Vector3(pl2.position.x + horizontalInput * 2.7f, pl2.position.y, 0f);
        yield return new WaitForSeconds(.02f);
        gentelmen3T.position = new Vector3(pl2.position.x + horizontalInput * 2.9f, pl2.position.y, 0f);
        gentelmen3O.SetActive(false);

        yield return new WaitForSeconds(.5f);
        gstage = 0;

        g3active = false;
        pl1Gm3HS = false;
        yield return null;
    }

    IEnumerator Spikey2()
    {
        pl2Meter -= 75f;
        urMom2.SetActive(true);
        yield return new WaitForSeconds(.9f);
        urMom2.SetActive(false);
        yield return null;
    }

    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.name == "uppercut")
        { 
                hitStunMultiplier2 = 1;
                bonusHitstun2 = 1f;
                StartCoroutine(HitStun());
            pl2RB.AddForce(0, -pl2RB.velocity.y, 0, ForceMode.VelocityChange);
            pl2RB.AddForce(pl1Fight.pl1horizontalInput * pl2Perc / 300f, 300f + pl2Perc / 2.5f, 0);
                pl2Perc += 50f;
            
            
        }

        if (collision.gameObject.name == "pl2gm1" && pl1Fight.pl2Gm1HS == false)
        {
            pl1Fight.pl2Gm1HS = true;
            hitStunMultiplier2 = 0;
            bonusHitstun2 = .05f;
            StartCoroutine(HitStun());
            pl2RB.AddForce(0, -pl2RB.velocity.y, 0, ForceMode.VelocityChange);
            pl2RB.AddForce(pl1Fight.pl1horizontalInput * pl2Perc / 500f, 200f, 0);
            pl2Perc += 50f;
        }

        if (collision.gameObject.name == "pl2gm2" && pl1Fight.pl2Gm2HS == false)
        {
            pl1Fight.pl2Gm2HS = true;
            hitStunMultiplier2 = .2f;
            bonusHitstun2 = .05f;
            StartCoroutine(HitStun());
            pl2RB.AddForce(0, -pl2RB.velocity.y, 0, ForceMode.VelocityChange);
            pl2RB.AddForce(pl1Fight.pl1horizontalInput * pl2Perc / 500f, -300f, 0);
            pl2Perc += 30f;
        }

        if (collision.gameObject.name == "pl2gm3" && pl1Fight.pl2Gm3HS == false)
        {
            pl1Fight.pl2Gm3HS = true;
            hitStunMultiplier2 = .5f;
            bonusHitstun2 = .1f;
            StartCoroutine(HitStun());
            pl2RB.AddForce(0, -pl2RB.velocity.y, 0, ForceMode.VelocityChange);
            pl2RB.AddForce(pl1Fight.pl1horizontalInput * (pl2Perc / 5f) + pl1Fight.pl1horizontalInput * 400f, 50f, 0);
            pl2Perc += 90f;
        }

        if (collision.gameObject.name == "urMom")
        {
            hitStunMultiplier2 = .2f;
            bonusHitstun2 = .2f;
            StartCoroutine(HitStun());
           
            pl2RB.AddForce(0, -pl2Perc * 5f, 0);
            pl2Perc += 50f;
        }

    }

    IEnumerator HitStun()
    {
        hitStun = true;
        pl2MeshRender.material = lpurple;
        yield return new WaitForSeconds(hitStunMultiplier2 * (Mathf.Pow(pl2Perc, 1.2f) / 10000f) + bonusHitstun2);
        hitStun = false;
        pl2MeshRender.material = purple;

        yield return null;
    }

}

