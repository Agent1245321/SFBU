using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Movemnt1 : MonoBehaviour
{
    public Rigidbody PL1;
    public BoxCollider PL1COL;
    public BoxCollider Stage;
    public float setSpeed;
    public float jumpHeight;
    public float speedCap;
    public float friction;
    public Transform PL1T;
    
    
    private float jumps = 0;
    //private bool isGrounded = false;
    private float currentSpeed;
    private float currentVertical;
    private float speed;


    // Start is called before the first frame update

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentSpeed = PL1.velocity.x;
        currentVertical = PL1.velocity.y;


        if(Input.GetKey("a") && currentSpeed >= -speedCap)
        {
            PL1.AddForce(-speed * .1f, 0, 0, ForceMode.VelocityChange);
        }

        if (Input.GetKey("d") && currentSpeed <= speedCap)
        {
            PL1.AddForce(speed * .1f, 0, 0, ForceMode.VelocityChange);
        }

        if(Input.GetKeyDown("w") && jumps > 0)
        {
            PL1.AddForce(0, -currentVertical + jumpHeight, 0, ForceMode.VelocityChange);
            jumps = jumps - 1;
          // isGrounded = false;
        }


        if (Input.GetKeyDown("e") && jumps > 0)
        {
            PL1.AddForce(-currentSpeed + (setSpeed * 5f), (-currentVertical + (jumpHeight *.75f)), 0, ForceMode.VelocityChange);
            speed = .25f * setSpeed;
            jumps = jumps - 1;
            PL1.freezeRotation = false;

        }

        if (Input.GetKeyDown("q") && jumps > 0)
        {
            PL1.AddForce(-currentSpeed + (-setSpeed * 5f), (-currentVertical + (jumpHeight * .75f)), 0, ForceMode.VelocityChange);
            speed = .25f * setSpeed;
            jumps = jumps - 1;
            PL1.freezeRotation = false;

        }


       // Debug.Log(jumps);
        
    }

    void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "Stage")
        {
            // isGrounded = true;
            speed = setSpeed;
            jumps = 2;
            PL1.rotation = Quaternion.Euler(0, 0, 0);
            
        }

        if(collision.gameObject.tag == "BlastZone")
        {
            PL1T.position = new Vector3(-3, 1.3f, 0 );
        }
    }

    void OnTriggerExit(Collider collision)
    {
        //isGrounded = false;
    }
    

    void OnTriggerStay(Collider collision)
    {
        if (!Input.GetKey("a") && !Input.GetKey("d"))
        {
            PL1.AddForce(-currentSpeed * friction, 0f, 0f, ForceMode.VelocityChange);
        }
    }
}
