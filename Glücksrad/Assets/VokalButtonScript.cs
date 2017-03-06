using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VokalButtonScript : MonoBehaviour {
    
    public static bool onVokalClicked = true;
    public static string Vokal;



    // Use this for initialization
    void Start () {

        


    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("AlreadyTurned : " + DrehungScript.AlreadyTurned);
        Debug.Log("VokalKaufenCheck : " + WordsManager.VokalKaufenCheck);
       
        if (WordsManager.VokalKaufenCheck == true && WordsManager.score > 250 && DrehungScript.AlreadyTurned == true )
        {
            GameObject VokalButton = gameObject;
            Text VokalButtonText = VokalButton.GetComponentInChildren<Text>();
            VokalButtonText.enabled = true;
            gameObject.GetComponent<Image>().enabled = true;

        }
        else if (onVokalClicked && WordsManager.VokalKaufenCheck == false)
        {
            GameObject VokalButton = gameObject;
            Text VokalButtonText = VokalButton.GetComponentInChildren<Text>();
            VokalButtonText.enabled = false;
            gameObject.GetComponent<Image>().enabled = false;
            onVokalClicked = false;
            WordsManager.VokalKaufenCheck = false ;

        }
        else
        {
            GameObject VokalButton = gameObject;
            Text VokalButtonText = VokalButton.GetComponentInChildren<Text>();
            VokalButtonText.enabled = false;
            gameObject.GetComponent<Image>().enabled = false;
            WordsManager.VokalKaufenCheck = false;
        }
    }

    public void OnVokalClick()
    {
        GameObject VokalButton = gameObject;
        Text VokalButtonText = VokalButton.GetComponentInChildren<Text>();
        Vokal = VokalButtonText.text;
        onVokalClicked = true;

    }
}
