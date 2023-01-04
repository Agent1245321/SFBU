using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class Movemnt1 : MonoBehaviour
{
    public Rigidbody pl1;
    public GameObject pl1GO;
    public BoxCollider pl1Col;
    public BoxCollider stage;
    public float setSpeed;
    public float jumpHeight;
    public float speedCap;
    public float friction;
    public Transform pl1t;
    public static bool isDed = false;
    public GameObject Explosion;
    public ParticleSystem explosionPart;


    private float jumps = 0;
    //private bool isGrounded = false;
    private float currentSpeed;
    private float currentVertical;
    private float speed;
    
    
    private float controllerHorizontal2;
    private bool jump;
    private bool canJump;
    private float currentRotZ;
    private float currentRotY;
    private bool gameOver;
    private bool hitStun;
    public bool pl1controller;
    private Vector3 colTransform;


    //Controller Managment

    private float pl1InputHorizontal;
    private float pl1InputVertical;
    private float pl1InputLLaunch;
    private float pl1InputRLaunch;
    void Update()
    {
        hitStun = pl1Fight.hitStun;

        if (gameOver == true)
        {
            pl1.constraints = RigidbodyConstraints.FreezeAll;
            
        }
       if(pl1controller == true)
        {
            pl1InputHorizontal = Input.GetAxis("Horizontal");
            pl1InputVertical = Input.GetAxis("Vertical");
            controllerHorizontal2 = Input.GetAxis("Joystick1Horizontal2");
        }
       else
        {
            Debug.Log(ControllerManagers.pl1Axis2);
            pl1InputHorizontal = ControllerManagers.pl1Axis2;
            pl1InputVertical = ControllerManagers.pl1Axis1;
        }
        
        
        currentRotY = pl1.angularVelocity.y;
        currentRotZ = pl1.angularVelocity.z;

        currentSpeed = pl1.velocity.x;
        currentVertical = pl1.velocity.y;
        gameOver = Manager.gameOver;


        //Debug.Log(CurrentRotZ);
        if (pl1.angularVelocity.magnitude > 1)
        {
            //Debug.Log("SPIN");
        }
        
            if (isDed == true)
        {
            
            if (Math.Abs(pl1t.transform.position.x) > .3f)
            {
                pl1.velocity = new Vector3(0, 0, 0);
                pl1t.transform.position = new Vector3(pl1t.transform.position.x / 1.025f, -.01f * (pl1t.transform.position.x * pl1t.transform.position.x) + 16f, 0f);
                //Debug.Log(PL1T.transform.position.x);
            }

            if (Math.Abs(pl1t.transform.position.x) < .4f)
            {
                pl1.velocity = new Vector3(0, -50f, 0);
                pl1t.transform.position = new Vector3(0f, 16f, 0f);
                isDed = false;
                explosionPart.Stop();
            }
        }

        //check for vertical stick input
        if (pl1InputVertical > .8f && hitStun == false)
        {
            jump = true;
        }
        else
        {
            jump = false;
        }
        //checks if stick was released and allows you to jump
        if (pl1InputVertical < .8f)
        {
            canJump = true;
        }

        if (pl1InputVertical < -.8f)
        {
            pl1GO.transform.localScale = new Vector3(1, 1, 1);
            pl1.AddForce(0, -1, 0, ForceMode.VelocityChange);
        }
        else
        {
            pl1GO.transform.localScale = new Vector3(1, 2, 1);
            
        }


        //Movement !
        if (pl1InputHorizontal < -.5 && currentSpeed >= -speedCap && hitStun == false)
        {
            pl1.AddForce(-speed * .1f, 0, 0, ForceMode.VelocityChange);
        }

        if (pl1InputHorizontal > .5 && currentSpeed <= speedCap && hitStun == false)
        {
            pl1.AddForce(speed * .1f, 0, 0, ForceMode.VelocityChange);
        }

        if(jump == true && jumps > 0 && canJump == true)
        {
            canJump = false;
            pl1.AddForce(0, -currentVertical + jumpHeight, 0, ForceMode.VelocityChange);
            jumps = jumps - 1;
            // isGrounded = false;
            
        }

       
        if ((Input.GetButtonDown("Joystick5") || Input.GetKeyDown(ControllerManagers.pl1KeyLLaunch)) && jumps > 0 && hitStun == false)
        {
            pl1.angularVelocity = new Vector3(0, currentRotY , -6);
            pl1.AddForce(-currentSpeed + (setSpeed * 5f), (-currentVertical + (jumpHeight *.75f)), 0, ForceMode.VelocityChange);
            speed = .25f * setSpeed;
            jumps = jumps - 1;
            pl1.freezeRotation = false;

        }

        if ((Input.GetButtonDown("Joystick4") || Input.GetKeyDown(ControllerManagers.pl1KeyRLaunch)) && jumps > 0 && hitStun == false)
        {
            pl1.angularVelocity = new Vector3(0, currentRotY, 6);
            pl1.AddForce(-currentSpeed + (-setSpeed * 5f), (-currentVertical + (jumpHeight * .75f)), 0, ForceMode.VelocityChange);
            speed = .25f * setSpeed;
            jumps = jumps - 1;
            pl1.freezeRotation = false;

        }


        
        if (controllerHorizontal2 > .8f)
        {
            //pl1.angularVelocity = new Vector3(0, -10, currentRotZ);
        }

        if (controllerHorizontal2 < -.8f)
        {
           // pl1.angularVelocity = new Vector3(0, 10, currentRotZ);
        }


    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "BlastZone")
        {
            if (isDed == false)
            {
                colTransform = collision.GetContact(0).point;
                Explosion.transform.position = colTransform;
                explosionPart.Play();
                pl1.velocity = new Vector3(0, 0, 0);
                jumps = 0;
                pl1.AddForce(-currentSpeed, -currentVertical, 0, ForceMode.VelocityChange);
                isDed = true;

                
            }
        }
    }
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Stage")
        {
            isDed = false;
            speed = setSpeed;
            jumps = 2;
            pl1.rotation = Quaternion.Euler(0, 0, 0);

        }
    }

    void OnTriggerExit(Collider collision)
    {
        //isGrounded = false;
    }
    

    void OnTriggerStay(Collider collision)
    {
        if (isDed == false){
            if (!Input.GetKey("a") && !Input.GetKey("d"))
            {
                pl1.AddForce(-currentSpeed * friction, 0f, 0f, ForceMode.VelocityChange);
                //Debug.Log("HAHAH");
            }
        }
    }

    public void StartGame()
    {
        pl1.transform.position = new Vector3(-5f, 1.3f, 0f);
        pl1.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX;
    }
}
