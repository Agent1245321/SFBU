using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class Movemnt1 : MonoBehaviour
{
    public Rigidbody pl1;
    public BoxCollider pl1Col;
    public BoxCollider stage;
    public float setSpeed;
    public float jumpHeight;
    public float speedCap;
    public float friction;
    public Transform PL1T;
    public static bool isDed = false;


    private float jumps = 0;
    //private bool isGrounded = false;
    private float currentSpeed;
    private float currentVertical;
    private float speed;
    
    private float controllerInput;
    private float controllerVertical;
    private float controllerHorizontal2;
    private bool jump;
    private bool canJump;
    private float currentRotX;
    private float currentRotY;
    private bool gameOver;
    

 
    void Update()
    {

        if (gameOver == true)
        {
            pl1.constraints = RigidbodyConstraints.FreezeAll;
            
        }
       
        controllerInput = Input.GetAxis("Horizontal");
        controllerVertical = Input.GetAxis("Vertical");
        controllerHorizontal2 = Input.GetAxis("Joystick1Horizontal2");
        currentRotY = (pl1.angularVelocity.y);
        currentRotX = (pl1.angularVelocity.z);

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
           
            if (Math.Abs(PL1T.transform.position.x) > 1)
            {
                PL1T.transform.position = new Vector3(PL1T.transform.position.x / 1.1f, 16f, 0f);
                //Debug.Log(PL1T.transform.position.x);
            }

            if (Math.Abs(PL1T.transform.position.x) < 1)
            {
                pl1.AddForce(-currentSpeed, 0, 0, ForceMode.VelocityChange);
                isDed = false;
            }
        }

        //check for vertical stick input
        if (controllerVertical > .8f)
        {
            jump = true;
        }
        else
        {
            jump = false;
        }
        //checks if stick was released and allows you to jump
        if (controllerVertical < .8f)
        {
            canJump = true;
        }

        if (controllerInput < -.5 && currentSpeed >= -speedCap)
        {
            pl1.AddForce(-speed * .1f, 0, 0, ForceMode.VelocityChange);
        }

        if (controllerInput > .5 && currentSpeed <= speedCap)
        {
            pl1.AddForce(speed * .1f, 0, 0, ForceMode.VelocityChange);
        }

        if(jump == true && jumps > 0 && canJump == true)
        {
            canJump = false;
            pl1.AddForce(0, -currentVertical + jumpHeight, 0, ForceMode.VelocityChange);
            jumps = jumps - 1;
            // isGrounded = false;
            //Debug.Log("Jump");
        }


        if (Input.GetButtonDown("Joystick5") && jumps > 0)
        {
            pl1.angularVelocity = new Vector3(0, currentRotY , -6);
            pl1.AddForce(-currentSpeed + (setSpeed * 5f), (-currentVertical + (jumpHeight *.75f)), 0, ForceMode.VelocityChange);
            speed = .25f * setSpeed;
            jumps = jumps - 1;
            pl1.freezeRotation = false;

        }

        if (Input.GetButtonDown("Joystick4") && jumps > 0)
        {
            pl1.angularVelocity = new Vector3(0, currentRotY, 6);
            pl1.AddForce(-currentSpeed + (-setSpeed * 5f), (-currentVertical + (jumpHeight * .75f)), 0, ForceMode.VelocityChange);
            speed = .25f * setSpeed;
            jumps = jumps - 1;
            pl1.freezeRotation = false;

        }


        // Debug.Log(jumps);
        //Debug.Log(controllerHorizontal2);
        if (controllerHorizontal2 > .8f)
        {
            pl1.angularVelocity = new Vector3(0, -10, currentRotX);
        }

        if (controllerHorizontal2 < -.8f)
        {
            pl1.angularVelocity = new Vector3(0, 10, currentRotX);
        }


    }

    void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "Stage")
        {
            // isGrounded = true;
            speed = setSpeed;
            jumps = 2;
            pl1.rotation = Quaternion.Euler(0, 0, 0);
            
        }

        if(collision.gameObject.tag == "BlastZone")
        {
            jumps = 0;
            pl1.AddForce(-currentSpeed, 0, 0, ForceMode.VelocityChange);
            isDed = true;
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
