using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pl1Fight : MonoBehaviour
{
    private float pl1Perc;
    private float pl1Meter = 0;
    private bool hitStun;
    public Transform upperCut;
    public Transform pl1;
    public GameObject uppercutCol;
    public ParticleSystem uppercutParticals;
    public Rigidbody pl1RB;


    private void Start()
    {
        StartCoroutine(MeterBurn());
    }


    IEnumerator MeterBurn()
    {
        
        while (pl1Meter < 100)
        {
            yield return new WaitForSeconds(.1f);
            pl1Meter += 5;
        }

        
    }

    [System.Obsolete]
    public void Update()
    {
        Debug.Log(pl1Meter);
        if (Input.GetButtonDown("Joystick1-1"))
        {
            StartCoroutine(UpperCut());
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
            upperCut.position = new Vector3(pl1.transform.position.x + .8f, pl1.transform.position.y - .75f, 0f);
            yield return new WaitForSeconds(.02f);
            uppercutParticals.enableEmission = true;

            upperCut.position = new Vector3(pl1.transform.position.x + 1f, pl1.transform.position.y - .5f, 0f);
            yield return new WaitForSeconds(.02f);

            upperCut.position = new Vector3(pl1.transform.position.x + 1.1f, pl1.transform.position.y - .25f, 0f);
            yield return new WaitForSeconds(.02f);



            upperCut.position = new Vector3(pl1.transform.position.x + 1.2f, pl1.transform.position.y, 0f);
            yield return new WaitForSeconds(.02f);

            upperCut.position = new Vector3(pl1.transform.position.x + 1.3f, pl1.transform.position.y + .25f, 0f);
            yield return new WaitForSeconds(.02f);

            upperCut.position = new Vector3(pl1.transform.position.x + 1.3f, pl1.transform.position.y + .5f, 0f);
            yield return new WaitForSeconds(.02f);

            upperCut.position = new Vector3(pl1.transform.position.x + 1.2f, pl1.transform.position.y + .75f, 0f);
            yield return new WaitForSeconds(.02f);
            
            uppercutParticals.enableEmission = false;
            uppercutCol.SetActive(false);


            yield return null;
        }
    }
    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.name == "Sphere")
        {
            pl1RB.AddForce(100f * pl1Perc / 500f, 100f * pl1Perc / 100f, 0);
            pl1Perc += 20f;

        }
    }

}
