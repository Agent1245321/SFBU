using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MovementTwo : MonoBehaviour
{
    public Rigidbody pl2;
    public BoxCollider pl2Col;
    public BoxCollider stage;
    public float setSpeed;
    public float jumpheight2;
    public float speedCap2;
    public float friction;
    public Transform pl2t;
    public static bool isDed = false;

    private float jumps2 = 0;
    //private bool isGrounded2 = false;
    private float currentspeed2;
    private float currentVertical2;
    private float controllerInput;
    private float controllerVertical;
    private bool jump;
    private bool canJump;
    private float speed2;
    private float currentRotZ;
    private float currentRotY;
    private bool gameOver;

    private float controllerHorizontal2;
    void Update()
    {

        if (gameOver == true)
        {
            pl2.constraints = RigidbodyConstraints.FreezeAll;
        }



        controllerInput = Input.GetAxis("HorizontalController");
        controllerVertical = Input.GetAxis("VerticalController");
        controllerHorizontal2 = Input.GetAxis("Joystick2Horizontal2");

        currentspeed2 = pl2.velocity.x;
        currentVertical2 = pl2.velocity.y;
        currentRotY = (pl2.angularVelocity.y);
        currentRotZ = (pl2.angularVelocity.z);
        gameOver = Manager.gameOver;



        //death script

        if (isDed == true)
        {

            if (Math.Abs(pl2t.transform.position.x) > .3f)
            {
                pl2.velocity = new Vector3(0, 0, 0);
                pl2t.transform.position = new Vector3(pl2t.transform.position.x / 1.025f, -.01f * (pl2t.transform.position.x * pl2t.transform.position.x) + 16f, 0f);
                //Debug.Log(PL2T.transform.position.x);
            }

            if (Math.Abs(pl2t.transform.position.x) < .4f)
            {
                pl2.velocity = new Vector3(0, -50f, 0);
                pl2t.transform.position = new Vector3(0f, 16f, 0f);
                isDed = false;
                
            }
        }

        //Debug.Log(jumps2);


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

        /*
        Button Inputs:
        Joystick4 = L1
        Joystick5 = R1
            */
        if (Input.GetButtonDown("Joystick2-5"))
        {
            //Debug.Log("Input");
        }

        //movement on the horizontal.
        if (controllerInput < -.5 && currentspeed2 >= -speedCap2)
        {
            pl2.AddForce(-speed2 * .1f, 0, 0, ForceMode.VelocityChange);
        }

        if (controllerInput > .5 && currentspeed2 <= speedCap2)
        {
            pl2.AddForce(speed2 * .1f, 0, 0, ForceMode.VelocityChange);
        }

        if (jump == true && jumps2 > 0 && canJump == true)
        {
            canJump = false;
            pl2.AddForce(0, -currentVertical2 + jumpheight2, 0, ForceMode.VelocityChange);
            jumps2 = jumps2 - 1;
            // isGrounded = false; extra
        }


        if (Input.GetButtonDown("Joystick2-5") && jumps2 > 0)
        {
            pl2.angularVelocity = new Vector3(0, currentRotY, -6);
            pl2.AddForce(-currentspeed2 + (setSpeed * 5f), (-currentVertical2 + (jumpheight2 * .75f)), 0, ForceMode.VelocityChange);
            speed2 = setSpeed * .25f;
            jumps2 = jumps2 - 1;
            pl2.freezeRotation = false;

        }

        if (Input.GetButtonDown("Joystick2-4") && jumps2 > 0)
        {
            pl2.angularVelocity = new Vector3(0, currentRotY, 6);
            pl2.AddForce(-currentspeed2 + (-setSpeed * 5f), (-currentVertical2 + (jumpheight2 * .75f)), 0, ForceMode.VelocityChange);
            speed2 = setSpeed * .25f;
            jumps2 = jumps2 - 1;
            pl2.freezeRotation = false;

        }

        if (controllerHorizontal2 > .8f)
        {
            //pl2.angularVelocity = new Vector3(0, -10, currentRotZ);
        }

        if (controllerHorizontal2 < -.8f)
        {
            //pl2.angularVelocity = new Vector3(0, 10, currentRotZ);
        }




    }

    // activates when players trigger activates
    void OnTriggerEnter(Collider collision)
    {
        //asks if the collision was with the stage
        if (collision.gameObject.tag == "Stage")
        {

            //resets jumps, and sets players rotation back to upright
            // isGrounded = true; extra
            jumps2 = 2;
            pl2.rotation = Quaternion.Euler(0, 0, 0);
            speed2 = setSpeed;
        }

        if (collision.gameObject.tag == "BlastZone")
        {
            if (isDed == false)
            {
                pl2.velocity = new Vector3(0, 0, 0);
                jumps2 = 0;
                pl2.AddForce(-currentspeed2, 0, -currentVertical2, ForceMode.VelocityChange);
                isDed = true;
            }
        }
    }

    /*
    void OnTriggerExit(Collider collision)
    {
        //isGrounded = false;  extra
    }
    */


    void OnTriggerStay(Collider collision)
    {
        if (controllerInput == 0)
        {
            pl2.AddForce(-currentspeed2 * friction, 0f, 0f, ForceMode.VelocityChange);
        }
    }

    public void StartGame()
    {
        pl2.transform.position = new Vector3(5f, 1.3f, 0f);
        pl2.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX;
    }

}
