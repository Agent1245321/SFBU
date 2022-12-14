using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    public TextMeshProUGUI timeUi;
    public TextMeshProUGUI score1UI;
    public TextMeshProUGUI score2UI;
    public TextMeshProUGUI perc1UI;
    public TextMeshProUGUI perc2UI;
    
    public GameObject endScreen;
    public TextMeshProUGUI endScreenText;
    public GameObject gameUI;
    
    public float timeset;
    public static bool gameOver;
    public bool testMode;
    public Image pl1MeterImg;
    public Image pl2MeterImg;
    


    private bool pl1Ded;
    private bool pl2Ded;
    private int score1;
    private int score2;
    private bool Dedlock1 = true;
    private bool Dedlock2 = true;
    private float time;
    private float pl1Perc;
    private float pl2Perc;

    private float verticalDpad;


    private void Awake()
    {
        StartCoroutine(GameTimeCountdown());
    }

    // Start is called before the first frame update
    void Start()
    {
        // ^ calls to start the timer
    }

    // Update is called once per frame
    void Update()
    {
        pl1Ded = Movemnt1.isDed;
        pl2Ded = MovementTwo.isDed;
        pl1Perc = pl1Fight.pl1Perc;
        pl2Perc = pl2Fight.pl2Perc;
        verticalDpad = Input.GetAxis("Joystick1Vertical3");

        if (pl1Ded == true)
        {
            Dedlock1 = false;
        }

        if(pl2Ded == true)
        {
            Dedlock2 = false;
        }

        if(Dedlock1 == false && pl1Ded == false)
        {
            score2 = score2 + 1;
            Dedlock1 = true;
            pl1Fight.pl1Perc = 0;
        }

        if (Dedlock2 == false && pl2Ded == false)
        {
            score1 = score1 + 1;
            Dedlock2 = true;
            pl2Fight.pl2Perc = 0;
        }

        if(verticalDpad > .8f)
        {

        }


        // Debug.Log(score1);
        //Debug.Log(score2);
        //Debug.Log(pl2Ded);

     
    }

   

    private void LateUpdate()
    {
        if (gameOver == false)
        {
            perc1UI.text = (pl1Perc/10).ToString() + "%";
            perc2UI.text = (pl2Perc/10).ToString() + "%";
            score1UI.text = score1.ToString();
            score2UI.text = score2.ToString();
            timeUi.text = time.ToString();
            pl1MeterImg.fillAmount = pl1Fight.pl1Meter / 100f;
            pl2MeterImg.fillAmount = pl2Fight.pl2Meter / 100f;
        }
       
    }

    //starts the timer and conttrols events linked to it
    IEnumerator GameTimeCountdown()
    {
        if(testMode == false)
        {
            pl1Fight.pl1Meter = 0f;
            pl2Fight.pl2Meter = 0f;
            gameOver = false;
            time = timeset;
            pl1Fight.pl1Perc = 0;
            pl2Fight.pl2Perc = 0;
            score1 = 0;
            score2 = 0;
            gameUI.SetActive(true);
            
            endScreen.SetActive(false);

            while (time > 0)
            {
                time -= 1;
                yield return new WaitForSeconds(1);
                
            }

            gameOver = true;

            endScreen.SetActive(true);

            if (score1 - score2 > 0)
            {
                endScreenText.text = "Player 1 Wins";
            }
            if (score1 - score2 < 0)
            {
                endScreenText.text = "Player 2 Wins";
            }
            if (score1 - score2 == 0)
            {
                endScreenText.text = "HmM A t!e";
            }

            yield return new WaitForSeconds(5);
            gameOver = false;

            SceneManager.LoadScene("Menu");
            

            //ends the routine
            yield return null;

        } 
    }

}
