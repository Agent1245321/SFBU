using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementTwo : MonoBehaviour
{
    public Rigidbody PL2;
    public BoxCollider PL2COL;
    public BoxCollider Stage;
    public float setSpeed;
    public float jumpheight2;
    public float speedCap2;
    public float friction;
    public Transform PL2T;

    private float jumps2 = 0;
    //private bool isGrounded2 = false;
    private float currentspeed2;
    private float currentVertical2;
    private float controllerInput;
    private float controllerVertical;
    private bool jump;
    private bool canJump;
    private float speed2;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        controllerInput = Input.GetAxis("HorizontalController");
        controllerVertical = Input.GetAxis("VerticalController");
        currentspeed2 = PL2.velocity.x;
        currentVertical2 = PL2.velocity.y;

        //Debug.Log(jumps2);


        //check for vertical stick input
        if(controllerVertical > .8f)
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
        if (Input.GetButtonDown("Joystick5"))
        {
            Debug.Log("Input");
        }

        //movement on the horizontal.
        if (controllerInput < -.5 && currentspeed2 >= -speedCap2)
        {
            PL2.AddForce(-speed2 * .1f, 0, 0, ForceMode.VelocityChange);
        }

        if (controllerInput > .5 && currentspeed2 <= speedCap2)
        {
            PL2.AddForce(speed2 * .1f, 0, 0, ForceMode.VelocityChange);
        }

        if (jump == true && jumps2 > 0 && canJump == true)
        {
            canJump = false;
            PL2.AddForce(0, -currentVertical2 + jumpheight2, 0, ForceMode.VelocityChange);
            jumps2 = jumps2 - 1;
            // isGrounded = false; extra
        }


        if (Input.GetButtonDown("Joystick5") && jumps2 > 0)
        {
            PL2.AddForce(-currentspeed2 + (setSpeed * 5f), (-currentVertical2 + (jumpheight2 * .75f)), 0, ForceMode.VelocityChange);
            speed2 = setSpeed * .25f;
            jumps2 = jumps2 - 1;
            PL2.freezeRotation = false;

        }

        if (Input.GetButtonDown("Joystick4") && jumps2 > 0)
        {
            PL2.AddForce(-currentspeed2 + (-setSpeed * 5f), (-currentVertical2 + (jumpheight2 * .75f)), 0, ForceMode.VelocityChange);
            speed2 = setSpeed * .25f;
            jumps2 = jumps2 - 1;
            PL2.freezeRotation = false;

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
            PL2.rotation = Quaternion.Euler(0, 0, 0);
            speed2 = setSpeed;
        }

        if (collision.gameObject.tag == "BlastZone")
        {
            PL2T.position = new Vector3(3, 1.3f, 0);
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
            PL2.AddForce(-currentspeed2 * friction, 0f, 0f, ForceMode.VelocityChange);
        }
    }

}
