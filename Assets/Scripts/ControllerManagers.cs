using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerManagers : MonoBehaviour
{
    // Start is called before the first frame update
    
    
    private string pl1KeyJab;
    private string pl1KeySpecial;
    private string pl1KeyLLaunch;
    private string pl1KeyRLaunch;
    private string pl1KeyUp;
    private string pl1KeyDown;
    private string pl1KeyLeft;
    private string pl1KeyRight;

    



    public static float pl1Axis1;
    public static float pl1Axis2;
    public static bool pl1Jab;
    public static bool pl1Special;
    public static bool pl1LLaunch;
    public static bool pl1RLLaunch;

    private string tempKeySelect;
    private int tempKey;

    public int controllerNum;



    private void Start()
    {
        pl1KeyUp = "w";
        pl1KeyDown = "s";
        pl1KeyLeft = "a";
        pl1KeyRight = "d";
    }
    private void Update()
    {
        Debug.Log(pl1KeyRight);
        if(Input.GetKey(pl1KeyUp)) { pl1Axis1 = 1f; }
        if(Input.GetKey(pl1KeyDown)) { pl1Axis1 = -1f; }
        if(Input.GetKey(pl1KeyRight)) { pl1Axis2 = 1f; }
        if(Input.GetKey(pl1KeyLeft)) { pl1Axis2 = -1f; }
        if(!Input.GetKey(pl1KeyUp) && !Input.GetKey(pl1KeyDown)) { pl1Axis1 = 0f; }
        if(!Input.GetKey(pl1KeyLeft) && !Input.GetKey(pl1KeyRight)) { pl1Axis2 = 0f; }
        if (Input.GetKey(pl1KeyUp)) { pl1Axis1 = 1f; }
        Debug.Log(pl1Axis2);
    }

    public void OnButtonPress1() { tempKey = 1; StartCoroutine(ButtonSelect()); }
    public void OnButtonPress2() { tempKey = 2; StartCoroutine(ButtonSelect()); }
    public void OnButtonPress3() { tempKey = 3; StartCoroutine(ButtonSelect()); }
    public void OnButtonPress4() { tempKey = 4; StartCoroutine(ButtonSelect()); }
    public void OnButtonPress5() { tempKey = 5; StartCoroutine(ButtonSelect()); }
    public void OnButtonPress6() { tempKey = 6; StartCoroutine(ButtonSelect()); }
    public void OnButtonPress7() { tempKey = 7; StartCoroutine(ButtonSelect()); }
    public void OnButtonPress8() { tempKey = 8; StartCoroutine(ButtonSelect()); }

    public IEnumerator ButtonSelect()
    {
        while (Input.inputString == "")
        {
            Debug.Log("Awaiting Input");
            yield return new WaitForSeconds(.01f);
            tempKeySelect = Input.inputString;
           
        }

        
        if (tempKey == 1) { pl1KeyJab = tempKeySelect; }
        if(tempKey == 2) { pl1KeySpecial = tempKeySelect; }
        if(tempKey == 3) { pl1KeyLLaunch = tempKeySelect; }
        if(tempKey == 4) { pl1KeyRLaunch = tempKeySelect; }
        if(tempKey == 5) { pl1KeyUp = tempKeySelect; }
        if(tempKey == 6) { pl1KeyDown = tempKeySelect; }
        if(tempKey == 7) { pl1KeyLeft = tempKeySelect; }
        if(tempKey == 8) { pl1KeyRight = tempKeySelect; }
        Debug.Log(pl1KeyJab);
        Debug.Log(pl1KeySpecial);
        Debug.Log(pl1KeyLLaunch);
        Debug.Log(pl1KeyRLaunch);
        
        yield return null;
    }
}

