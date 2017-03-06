using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrehungScript : MonoBehaviour {
    string [] PricesArray = {"500","400","300", "200", "Extra Dreh!", "700" , "200", "150", "450" , "Aussetzen",
                             "400", "250" , "900", "150", "400" , "600", "250", "350","Bankrott","750","800","300","200","1000" };

    float DrehungSpeed = 5;
    float result;
    float finalNumberAfterTurn;
    float angle;
    public static bool turnIsOn = false;
    public static bool canTurn = true;
    public static bool turnisOver = true;
    public static bool AlreadyTurned = false;
    public static bool Aussetzen = false;
    private int random ;
    public static float timer;
    public Text txt;
    public Text txt2;
    bool onCylinder = false;
    public static bool clicked = false;
    public static int score1 = 0;
    public static bool extradreh = false;
    public static bool Bankrott = false;
    AudioSource glücksradSound;
    public AudioClip glücksradAudioClip;
    // public Text score;


    // Use this for initialization
    void Start ()
    {
        random = Random.Range(4, 8);
        timer = random;
        glücksradSound = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Space)||(Input.GetMouseButtonDown(0)  && onCylinder))
        {

            
           
            clicked = true;
           
        }
        if (clicked)
        {
            
            Drehen();
            AlreadyTurned = true;
        }
        //Debug.Log(Input.mousePosition);
     
        
     }




    void Drehen()
    {
        if (canTurn == true)

        {

            txt2.enabled = true;
            turnIsOn = true;
        }

        if (turnIsOn && timer >= 0)
        {
            glücksradSound.PlayOneShot(glücksradAudioClip);
            txt2.enabled = false;
            timer -= Time.deltaTime;
            angle = transform.eulerAngles.x;
            transform.Rotate(0, (int)(DrehungSpeed) * timer, 0);
            //Debug.Log("EUlerAngle ===> " + angle);
            //Debug.Log("RotateAngle ===> " + transform.rotation.x);
            result = angle / 15f;
            result = Mathf.Round(result);
            random = Random.Range(4, 8);

            //Debug.Log("Result " + result);

            finalNumberAfterTurn = FinalResult(DrehungCountScript.drehnum, angle);
            if (finalNumberAfterTurn < 24)
            {
                txt.text = PricesArray[(int)finalNumberAfterTurn];
            }
            
            
        }
        else
        {
            clicked = false;
            turnIsOn = false;
            timer = random;


        }
            if (timer <= 0)
            {
            glücksradSound.Stop();
            //score.text = WordsManager.score.ToString();
            if (txt.text.Contains("Extra Dreh!"))
            {
                extradreh = true;
                Debug.Log(txt.text);
            }
            else if (txt.text.Contains("Bankrott"))
            {
                Bankrott = true;
               
                Debug.Log(txt.text);
            }
            else if (txt.text.Contains("Aussetzen"))
            {
                Aussetzen = true;
                Debug.Log(txt.text);
            }
            else
            {
                score1 = int.Parse(txt.text);
            }

                canTurn = false;
                turnisOver = false;
               
            }
        
    }


    float FinalResult (int drehnum , float angle)
    {
        float result2 = 0;

        if (drehnum == 1)
        {
            result2 = angle / 15f;
            result2 = Mathf.Round(result2);
           // Debug.Log("Result " + result2); 

        }

        else if (drehnum == 2 && angle < 90)
        {
            result2 = (180 - angle) / 15f;
            result2 = Mathf.Round(result2);
           // Debug.Log("Result " + result2);

        }

        else if (drehnum == 2 && ((360 > angle) && (angle > 90)))
        {
            result2 = (angle - 180) / 15f;
            result2 = 24 - (Mathf.Round(result2));
           // Debug.Log("Result " + result2);

        }
        else if (drehnum == 3 && ((360 > angle) && (angle > 180)))
        {
            result2 = angle / 15f;
            result2 = (Mathf.Round(result2));
           // Debug.Log("Result " + result2);

        }
        return result2;

    }

    private void OnMouseEnter()
    {
     
            Debug.Log("mouse is on Cylender");
            onCylinder = true;

        
     
    }

    private void OnMouseExit()
    {

        Debug.Log("mouse is out ");
        onCylinder = false;



    }

    


}

