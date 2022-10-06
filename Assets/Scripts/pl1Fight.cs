using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pl1Fight : MonoBehaviour
{
    public static float pl1Perc;
    public static float pl1Meter = 0;
    public static bool hitStun;
    public Transform upperCut;
    public Transform pl1;
    public GameObject uppercutCol;
    public ParticleSystem uppercutParticals;
    public Rigidbody pl1RB;
    public static float pl1horizontalInput;
    private bool meterLock;
    
    public Material red;
    public Material lred;
    public MeshRenderer pl1MeshRender;
    private float bonusHitstun;
    private float hitStunMultiplier;

    public static bool pl2Gm1HS;
    public static bool pl2Gm2HS;
    public static bool pl2Gm3HS;

    

    //gentelemn
    private int gstage;
    public Transform gentelmen1T;
    public Transform gentelmen2T;
    public Transform gentelmen3T;
    public GameObject gentelmen1O;
    public GameObject gentelmen2O;
    public GameObject gentelmen3O;

    private bool g2active;
    private bool g3active;



    private void Start()
    {
     
        StartCoroutine(MeterBurn());
    }


    IEnumerator MeterBurn()
    {
        
        while (pl1Meter < 100)
        {
            yield return new WaitForSeconds(.5f);
            pl1Meter += 2;
        }

        meterLock = true;

        yield return null;

        
    }

    [System.Obsolete]
    public void Update()
    {






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
            pl1horizontalInput = 1;
        }

        if (Input.GetAxis("Joystick1Horizontal2") < -0.8f)
        {
            pl1horizontalInput = -1;

        }

        if (Input.GetButtonDown("Joystick1-0") && hitStun == false)
        {


            if (gstage == 0)
            {
                StartCoroutine(Gentelmen1());
            }
            gstage += 1;
        }
    }

    private void FixedUpdate()
    {
       
    }

    [System.Obsolete]
    IEnumerator UpperCut()
    {
        if (pl1Meter >= 50)
        {
            pl1Meter -= 50f;
            uppercutCol.SetActive(true);
            upperCut.position = new Vector3(pl1.transform.position.x + pl1horizontalInput * .8f, pl1.transform.position.y - .75f, 0f);
            yield return new WaitForSeconds(.02f);
            uppercutParticals.enableEmission = true;

            upperCut.position = new Vector3(pl1.transform.position.x + pl1horizontalInput * 1f, pl1.transform.position.y - .5f, 0f);
            yield return new WaitForSeconds(.02f);

            upperCut.position = new Vector3(pl1.transform.position.x + pl1horizontalInput * 1.1f, pl1.transform.position.y - .25f, 0f);
            yield return new WaitForSeconds(.02f);          

            upperCut.position = new Vector3(pl1.transform.position.x + pl1horizontalInput * 1.3f, pl1.transform.position.y, 0f);
            yield return new WaitForSeconds(.02f);

            upperCut.position = new Vector3(pl1.transform.position.x + pl1horizontalInput * 1.5f, pl1.transform.position.y + .25f, 0f);
            yield return new WaitForSeconds(.02f);

            upperCut.position = new Vector3(pl1.transform.position.x + pl1horizontalInput * 1.7f, pl1.transform.position.y + .5f, 0f);
            yield return new WaitForSeconds(.02f);

            upperCut.position = new Vector3(pl1.transform.position.x + pl1horizontalInput * 1.5f, pl1.transform.position.y + .75f, 0f);
            yield return new WaitForSeconds(.02f);

            uppercutParticals.enableEmission = false;
            uppercutCol.SetActive(false);


            yield return null;
        }
    }

    IEnumerator Gentelmen1()
    {
        yield return new WaitForSeconds(.2f);

        gentelmen1T.position = new Vector3(pl1.position.x + pl1horizontalInput * .5f, pl1.position.y + -.5f, 0f);
        gentelmen1O.SetActive(true);
        gentelmen1T.position = new Vector3(pl1.position.x + pl1horizontalInput * .8f, pl1.position.y + -.4f, 0f);
        yield return new WaitForSeconds(.02f);

        if (gstage >= 2 && g2active == false)
        {
            StartCoroutine(Gentelmen2());
        }

        gentelmen1T.position = new Vector3(pl1.position.x + pl1horizontalInput * 1f, pl1.position.y + -.3f, 0f);
        yield return new WaitForSeconds(.02f);

        if (gstage >= 2 && g2active == false)
        {
            StartCoroutine(Gentelmen2());
        }

        gentelmen1T.position = new Vector3(pl1.position.x + pl1horizontalInput * 1.1f, pl1.position.y + .1f, 0f);
        yield return new WaitForSeconds(.02f);

        if (gstage >= 2)
        {
            StartCoroutine(Gentelmen2());
        }

        gentelmen1T.position = new Vector3(pl1.position.x + pl1horizontalInput * 1.2f, pl1.position.y + .5f, 0f);
        yield return new WaitForSeconds(.02f);

        if (gstage >= 2 && g2active == false)
        {
            StartCoroutine(Gentelmen2());
        }

        gentelmen1T.position = new Vector3(pl1.position.x + pl1horizontalInput * 1.3f, pl1.position.y + 1f, 0f);
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
        pl2Gm1HS = false;
        yield return null;
    }

    IEnumerator Gentelmen2()
    {
        g2active = true;
        yield return new WaitForSeconds(.1f);

        gentelmen2T.position = new Vector3(pl1.position.x + pl1horizontalInput * .5f, pl1.position.y + .8f, 0f);
        gentelmen2O.SetActive(true);
        gentelmen2T.position = new Vector3(pl1.position.x + pl1horizontalInput * .8f, pl1.position.y + .7f, 0f);
        yield return new WaitForSeconds(.02f);

        if (gstage >= 3 && g3active == false)
        {
            StartCoroutine(Gentelmen3());
        }

        gentelmen2T.position = new Vector3(pl1.position.x + pl1horizontalInput * 1f, pl1.position.y + .6f, 0f);
        yield return new WaitForSeconds(.02f);

        if (gstage >= 3 && g3active == false)
        {
            StartCoroutine(Gentelmen3());
        }

        gentelmen2T.position = new Vector3(pl1.position.x + pl1horizontalInput * 1.1f, pl1.position.y + .3f, 0f);
        yield return new WaitForSeconds(.02f);

        if (gstage >= 3 && g3active == false)
        {
            StartCoroutine(Gentelmen3());
        }

        gentelmen2T.position = new Vector3(pl1.position.x + pl1horizontalInput * 1.2f, pl1.position.y + -.1f, 0f);
        yield return new WaitForSeconds(.02f);

        if (gstage >= 3 && g3active == false)
        {
            StartCoroutine(Gentelmen3());
        }

        gentelmen2T.position = new Vector3(pl1.position.x + pl1horizontalInput * 1.3f, pl1.position.y + -.6f, 0f);
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
        pl2Gm2HS = false;
        yield return null;
    }

    IEnumerator Gentelmen3()
    {
        g3active = true;
        yield return new WaitForSeconds(.1f);

        gentelmen3T.position = new Vector3(pl1.position.x + pl1horizontalInput * .5f, pl1.position.y, 0f);
        gentelmen3O.SetActive(true);
        gentelmen3T.position = new Vector3(pl1.position.x + pl1horizontalInput * .6f, pl1.position.y, 0f);
        yield return new WaitForSeconds(.02f);
        gentelmen3T.position = new Vector3(pl1.position.x + pl1horizontalInput * .8f, pl1.position.y, 0f);
        yield return new WaitForSeconds(.02f);
        gentelmen3T.position = new Vector3(pl1.position.x + pl1horizontalInput * 1f, pl1.position.y, 0f);
        yield return new WaitForSeconds(.02f);
        gentelmen3T.position = new Vector3(pl1.position.x + pl1horizontalInput * 1.3f, pl1.position.y, 0f);
        yield return new WaitForSeconds(.02f);
        gentelmen3T.position = new Vector3(pl1.position.x + pl1horizontalInput * 1.6f, pl1.position.y, 0f);
        gentelmen3O.SetActive(false);

        yield return new WaitForSeconds(.5f);
        gstage = 0;

        g3active = false;
        pl2Gm3HS = false;
        yield return null;
    }
    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.name == "uppercut2")
        {
            hitStunMultiplier = 1;
            bonusHitstun = 1f;
            StartCoroutine(HitStun());
            pl1RB.AddForce(pl2Fight.horizontalInput * pl1Perc / 500f, -pl1RB.velocity.y + pl1Perc / 2.5f, 0);
            pl1Perc += 50f;
        }

        if (collision.gameObject.name == "gm1" && pl2Fight.pl1Gm1HS == false)
        {
            pl2Fight.pl1Gm1HS = true;
            hitStunMultiplier = 0;
            bonusHitstun = .05f;
            StartCoroutine(HitStun());
            pl1RB.AddForce(pl2Fight.horizontalInput * pl1Perc / 500f,  -pl1RB.velocity.y + pl1Perc / 10f, 0);
            pl1Perc += 50f;
        }

        if (collision.gameObject.name == "gm2" && pl2Fight.pl1Gm2HS == false)
        {
            pl2Fight.pl1Gm2HS = true;
            hitStunMultiplier = .2f;
            bonusHitstun = .05f;
            StartCoroutine(HitStun());
            pl1RB.AddForce(pl2Fight.horizontalInput * pl1Perc / 500f, -pl1RB.velocity.y + -pl1Perc / 20f, 0);
            pl1Perc += 30f;
        }

        if (collision.gameObject.name == "gm3" && pl2Fight.pl1Gm3HS == false)
        {
            pl2Fight.pl1Gm3HS = true;
            hitStunMultiplier = .5f;
            bonusHitstun = .1f;
            StartCoroutine(HitStun());
            pl1RB.AddForce(pl2Fight.horizontalInput * (pl1Perc / 5f), -pl1RB.velocity.y + pl1Perc / 5f, 0);
            pl1Perc += 90f;
        }
    }



    IEnumerator HitStun()
    {
        hitStun = true;
        pl1MeshRender.material = lred;
        yield return new WaitForSeconds(hitStunMultiplier * (Mathf.Pow(pl1Perc, 1.2f) / 10000f) + bonusHitstun);
        hitStun = false;
        pl1MeshRender.material = red;

        yield return null;
    }

}
