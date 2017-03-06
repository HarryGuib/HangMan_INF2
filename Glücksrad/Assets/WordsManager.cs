using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class WordsManager : MonoBehaviour {

    #region Text Variabeln
    public Text[] LettersMatrix = new Text[52];
    public Text PlayerStatus;
    public Text word;
    public Text OkButtonTxt;
    public Text FieldTxt1;
    public Text FieldTxt2;
    public Text scoreTxt;
    #endregion

    #region Bool 
    public static bool WordFound = false;
    public static bool VokalKaufenCheck = false;
    public static bool VokalKaufenCheck2 = false;
    public static bool Vokalcheck = true;
    public static bool Player1Turn = true;
    public static bool Player2Turn = false;
    public static bool Player3Turn = false;
    public static bool buttonClicked = false;
    bool check = false;
    bool letterAlreadyThere = false;
    bool player1finish = false;
    bool player2finish = false;
    bool player3finish = false;
    bool onRatenClicked = false;
    #endregion

    #region int 
    public static int score = 0;
    public static int score2 = 0;
    public static int score3 = 0;
    int[] indexArray = new int[52];
    int LetterNumber = 0;
    int numberOfletter = 0;
    int wordsCounter = 0;
    private int i = 0;
    private int counter = 0;
    #endregion

    #region Sound
    public AudioSource ApplausSound;
    public AudioSource GewinnSound;
    public AudioSource GewinnSound2;

    #endregion

    #region GameObjects
    public GameObject VokalKaufenButton;
    public GameObject RatenButton;
    public GameObject ReturnMenuButton;
    public GameObject ReplayGameButton;
    public GameObject OkButton2GO;
    public GameObject RatenFieldGO;
  

    #endregion

 
    protected FileInfo SourceFile = null;
    protected StreamReader Linereader = null;
    protected string textFromFile = "";
    string letter = "";
    public InputField Field;
    public InputField RatenField;
    public static char[] CharArray;
    public Button OkButton;
    public Button OkButton2;
    Light licht ;

    // Use this for initialization

    void Start () {
        score = 0;
        score2 = 0;
        score3 = 0;
        Player1Turn = true;
        Player2Turn = false;
        Player3Turn = false;
        licht = GameObject.Find("Directional Light").GetComponent<Light>();
        SourceFile = new FileInfo(@"C:\Users\Ariguib\Documents\Escape the room\Glücksrad\words.txt");
        Linereader = SourceFile.OpenText();
        //Debug.Log(check);
        Debug.Log(letter);
        if (textFromFile != null)
        {

            

            for (i = 0; i <= 51; i++)
            {
                LettersMatrix[i].color = Color.gray;
                LettersMatrix[i].text = "[ ]";
            }

            textFromFile = Linereader.ReadLine();
            Debug.Log(textFromFile);
            Debug.Log(textFromFile.Length);
            word.text = textFromFile;



            CharArray = word.text.ToCharArray();
            for (i = 0; i <= word.text.Length - 1; i++)
            {
                LettersMatrix[i + 13].color = Color.white;
                LettersMatrix[i].text = "[ ]";

                //LettersMatrix[i+13].text = CharArray[i].ToString();

            }


        }
      //  WordFound = false;


    }
	
	// Update is called once per frame
	void Update () {


        #region Player turns    
        if ( Player1Turn)
        {
            Debug.Log("Player 1");
            PlayerStatus.text = "Player 1";
            PlayerStatus.color = Color.cyan;
            player3finish = true;
            scoreTxt.text = "Score: " + score.ToString();
        }
        if (Player2Turn)
        {
            Debug.Log("Player 2");
            PlayerStatus.text = "Player 2";
            PlayerStatus.color = Color.red;
             player1finish = true;
            scoreTxt.text = "Score: " + score2.ToString();
        }
        if (Player3Turn)
        {
            Debug.Log("Player 3");
            PlayerStatus.text = "Player 3";
            PlayerStatus.color = Color.green;
             player2finish = true;
            scoreTxt.text = "Score: " + score3.ToString();
        }
        #endregion;
       
        Debug.Log("check : " + check);
        Debug.Log("WORDS COUNTER  : " + wordsCounter);
        #region Player 1 turn
        if (Player1Turn == true )
        {
            if (DrehungScript.canTurn == false)
            {

                OkButton.image.enabled = true;
                OkButtonTxt.enabled = true;
                Field.image.enabled = true;
                FieldTxt1.enabled = true;
                FieldTxt2.enabled = true;

            }


            #region Bankrott
            if (DrehungScript.Bankrott == true)
            {
                score = 0;
                scoreTxt.text = "Score: " + score.ToString();


                OkButton.image.enabled = false;
                OkButtonTxt.enabled = false;
                Field.image.enabled = false;
                FieldTxt1.enabled = false;
                FieldTxt2.enabled = false;
                VokalKaufenCheck = false;
                Player1Turn = false;
                Player2Turn = true;
                Player3Turn = false;
                DrehungScript.AlreadyTurned = false;
                DrehungScript.turnisOver = true;
                DrehungScript.canTurn = true;
                DrehungScript.Bankrott = false;


            }
            #endregion

            #region Extra Dreh
            if (DrehungScript.extradreh == true)
            {
                // letter = Field.text;
                //letter = letter.ToUpper();
                OkButton.image.enabled = false;
                OkButtonTxt.enabled = false;
                Field.image.enabled = false;
                FieldTxt1.enabled = false;
                FieldTxt2.enabled = false;
                DrehungScript.canTurn = true;
                DrehungScript.turnisOver = true;
                VokalKaufenCheck = false;
                DrehungScript.AlreadyTurned = false;
                DrehungScript.extradreh = false;

            }
            #endregion

            #region Raten
            if (onRatenClicked == true)
            {

                RatenFieldGO.SetActive(true);
                OkButton2GO.SetActive(true);

            }
            #endregion

            #region WordFound
            if ((WordFound == true) && textFromFile != null)
            {
                GewinnSound.Play();
                DrehungScript.canTurn = true;
                OkButton.image.enabled = false;
                OkButtonTxt.enabled = false;
                Field.image.enabled = false;
                FieldTxt1.enabled = false;
                FieldTxt2.enabled = false;

                for (i = 0; i <= 51; i++)
                {
                    LettersMatrix[i].color = Color.gray;
                    LettersMatrix[i].text = "[ ]";
                }

                textFromFile = Linereader.ReadLine();
                Debug.Log(textFromFile);
                Debug.Log(textFromFile.Length);
                word.text = textFromFile;



                CharArray = word.text.ToCharArray();
                for (i = 0; i <= word.text.Length - 1; i++)
                {
                    LettersMatrix[i + 13].color = Color.white;
                    LettersMatrix[i].text = "[ ]";

                    //LettersMatrix[i+13].text = CharArray[i].ToString();

                }


            }
            

            WordFound = false;

            #endregion

            #region Aussetzen
            if (DrehungScript.Aussetzen)
            {
                OkButton.image.enabled = false;
                OkButtonTxt.enabled = false;
                Field.image.enabled = false;
                FieldTxt1.enabled = false;
                FieldTxt2.enabled = false;
                DrehungScript.canTurn = true;
                DrehungScript.turnisOver = true;
                VokalKaufenCheck = false;
                DrehungScript.AlreadyTurned = false;
                DrehungScript.Aussetzen = false;

                NextPlayerTurn();
            }
            #endregion

            #region Vokal Kaufen 

            if (VokalKaufenCheck == true && score >= 250 && DrehungScript.AlreadyTurned == true)
            {
                OkButton.image.enabled = false;
                OkButtonTxt.enabled = false;
                Field.image.enabled = false;
                FieldTxt1.enabled = false;
                FieldTxt2.enabled = false;

                if (VokalButtonScript.onVokalClicked)
                {
                    
                    score = (score - 250)- DrehungScript.score1;
                    letter = VokalButtonScript.Vokal;
                    LetterCheck(letter);
                    //letter = "";
                    VokalKaufenCheck = false;
                    DrehungScript.AlreadyTurned = false;

                    //scoreTxt.text = "Score: " + score.ToString();
                }




                // DrehungScript.canTurn = true;
                //DrehungScript.turnisOver = true;





            }
            else if (VokalKaufenCheck == true && score < 250 && DrehungScript.AlreadyTurned == true)
            {


                OkButton.image.enabled = true;
                OkButtonTxt.enabled = true;
                Field.image.enabled = true;
                FieldTxt1.enabled = true;
                FieldTxt2.enabled = true;
                Debug.Log("Du hast nicht genug punkte um Vokale zu kaufen");

            }


            #endregion

           #region OnEnter  
           /* if (Input.GetKey("return"))
            {
                DrehungScript.AlreadyTurned = false;
                letter = Field.text;
                letter = letter.ToUpper();
                if (letter == "A" || letter == "E" || letter == "I" || letter == "O" || letter == "U" || letter == "" || letter.Length > 1)
                {
                    DrehungScript.canTurn = false;
                    DrehungScript.AlreadyTurned = true;

                }
                else
                {
                    LetterCheck(letter);
                }

            }*/
            #endregion
        }
        #endregion

        #region Player 2 turn
        if (Player2Turn == true)
        {
            if (DrehungScript.canTurn == false)
            {

                OkButton.image.enabled = true;
                OkButtonTxt.enabled = true;
                Field.image.enabled = true;
                FieldTxt1.enabled = true;
                FieldTxt2.enabled = true;

            }


            #region Bankrott
            if (DrehungScript.Bankrott == true)
            {
                score = 0;
                scoreTxt.text = "Score: " + score.ToString();


                OkButton.image.enabled = false;
                OkButtonTxt.enabled = false;
                Field.image.enabled = false;
                FieldTxt1.enabled = false;
                FieldTxt2.enabled = false;
                VokalKaufenCheck = false;
                DrehungScript.AlreadyTurned = false;
                DrehungScript.turnisOver = true;
                DrehungScript.canTurn = true;
                DrehungScript.Bankrott = false;
                Player1Turn = false;
                Player2Turn = false;
                Player3Turn = true;

            }
            #endregion

            #region Extra Dreh
            if (DrehungScript.extradreh == true)
            {
                // letter = Field.text;
                //letter = letter.ToUpper();
                OkButton.image.enabled = false;
                OkButtonTxt.enabled = false;
                Field.image.enabled = false;
                FieldTxt1.enabled = false;
                FieldTxt2.enabled = false;
                DrehungScript.canTurn = true;
                DrehungScript.turnisOver = true;
                VokalKaufenCheck = false;
                DrehungScript.AlreadyTurned = false;
                DrehungScript.extradreh = false;

            }
            #endregion

            #region Raten
            if (onRatenClicked == true)
            {

                RatenFieldGO.SetActive(true);
                OkButton2GO.SetActive(true);

            }
            #endregion

            #region WordFound
            if ((WordFound == true) && textFromFile != null)
            {
                GewinnSound.Play();
                DrehungScript.canTurn = true;
                OkButton.image.enabled = false;
                OkButtonTxt.enabled = false;
                Field.image.enabled = false;
                FieldTxt1.enabled = false;
                FieldTxt2.enabled = false;


                for (i = 0; i <= 51; i++)
                {
                    LettersMatrix[i].color = Color.gray;
                    LettersMatrix[i].text = "[ ]";
                }

                textFromFile = Linereader.ReadLine();
                Debug.Log(textFromFile);
                Debug.Log(textFromFile.Length);
                word.text = textFromFile;



                CharArray = word.text.ToCharArray();
                for (i = 0; i <= word.text.Length - 1; i++)
                {
                    LettersMatrix[i + 13].color = Color.white;
                    LettersMatrix[i].text = "[ ]";

                    //LettersMatrix[i+13].text = CharArray[i].ToString();

                }


            }
           
            WordFound = false;
            #endregion


            #region Vokal Kaufen 

            if (VokalKaufenCheck == true && score2 >= 250 && DrehungScript.AlreadyTurned == true)
            {
                OkButton.image.enabled = false;
                OkButtonTxt.enabled = false;
                Field.image.enabled = false;
                FieldTxt1.enabled = false;
                FieldTxt2.enabled = false;

                if (VokalButtonScript.onVokalClicked)
                {
                    score2 = (score2 - 250) - DrehungScript.score1;
                    letter = VokalButtonScript.Vokal;
                    LetterCheck(letter);
                    //letter = "";
                    VokalKaufenCheck = false;
                    DrehungScript.AlreadyTurned = false;

                    //scoreTxt.text = "Score: " + score.ToString();
                }




                // DrehungScript.canTurn = true;
                //DrehungScript.turnisOver = true;





            }
            else if (VokalKaufenCheck == true && score < 250 && DrehungScript.AlreadyTurned == true)
            {


                OkButton.image.enabled = true;
                OkButtonTxt.enabled = true;
                Field.image.enabled = true;
                FieldTxt1.enabled = true;
                FieldTxt2.enabled = true;
                Debug.Log("Du hast nicht genug punkte um Vokale zu kaufen");

            }


            #endregion

            #region Aussetzen
            if (DrehungScript.Aussetzen)
            {
                OkButton.image.enabled = false;
                OkButtonTxt.enabled = false;
                Field.image.enabled = false;
                FieldTxt1.enabled = false;
                FieldTxt2.enabled = false;
                DrehungScript.canTurn = true;
                DrehungScript.turnisOver = true;
                VokalKaufenCheck = false;
                DrehungScript.AlreadyTurned = false;
                DrehungScript.extradreh = false;

                NextPlayerTurn();
                DrehungScript.Aussetzen = false;
            }
            #endregion

            #region OnEnter  
            /* if (Input.GetKey("return"))
             {
                 DrehungScript.AlreadyTurned = false;
                 letter = Field.text;
                 letter = letter.ToUpper();
                 if (letter == "A" || letter == "E" || letter == "I" || letter == "O" || letter == "U" || letter == "" || letter.Length > 1)
                 {
                     DrehungScript.canTurn = false;
                     DrehungScript.AlreadyTurned = true;

                 }
                 else
                 {
                     LetterCheck(letter);
                 }

             }*/
            #endregion
        }
        #endregion

        #region Player 3 turn
        if (Player3Turn == true)
        {
            if (DrehungScript.canTurn == false)
            {

                OkButton.image.enabled = true;
                OkButtonTxt.enabled = true;
                Field.image.enabled = true;
                FieldTxt1.enabled = true;
                FieldTxt2.enabled = true;

            }


            #region Bankrott
            if (DrehungScript.Bankrott == true)
            {
                score = 0;
                scoreTxt.text = "Score: " + score.ToString();


                OkButton.image.enabled = false;
                OkButtonTxt.enabled = false;
                Field.image.enabled = false;
                FieldTxt1.enabled = false;
                FieldTxt2.enabled = false;
                VokalKaufenCheck = false;
                DrehungScript.AlreadyTurned = false;
                DrehungScript.turnisOver = true;
                DrehungScript.canTurn = true;
                DrehungScript.Bankrott = false;
                Player1Turn = true;
                Player2Turn = false;
                Player3Turn = false;

            }
            #endregion

            #region Extra Dreh
            if (DrehungScript.extradreh == true)
            {
                // letter = Field.text;
                //letter = letter.ToUpper();
                OkButton.image.enabled = false;
                OkButtonTxt.enabled = false;
                Field.image.enabled = false;
                FieldTxt1.enabled = false;
                FieldTxt2.enabled = false;
                DrehungScript.canTurn = true;
                DrehungScript.turnisOver = true;
                VokalKaufenCheck = false;
                DrehungScript.AlreadyTurned = false;
                DrehungScript.extradreh = false;

            }
            #endregion

            #region Aussetzen
            if (DrehungScript.Aussetzen)
            {
                OkButton.image.enabled = false;
                OkButtonTxt.enabled = false;
                Field.image.enabled = false;
                FieldTxt1.enabled = false;
                FieldTxt2.enabled = false;
                DrehungScript.canTurn = true;
                DrehungScript.turnisOver = true;
                VokalKaufenCheck = false;
                DrehungScript.AlreadyTurned = false;
                DrehungScript.extradreh = false;

                NextPlayerTurn();
                DrehungScript.Aussetzen = false;
            }
            #endregion

            #region Raten
            if (onRatenClicked == true)
            {

                RatenFieldGO.SetActive(true);
                OkButton2GO.SetActive(true);

            }
            #endregion

            #region WordFound
            if ((WordFound == true) && textFromFile != null)
            {
                GewinnSound.Play();
                DrehungScript.canTurn = true;
                OkButton.image.enabled = false;
                OkButtonTxt.enabled = false;
                Field.image.enabled = false;
                FieldTxt1.enabled = false;
                FieldTxt2.enabled = false;


                for (i = 0; i <= 51; i++)
                {
                    LettersMatrix[i].color = Color.gray;
                    LettersMatrix[i].text = "[ ]";
                }

                textFromFile = Linereader.ReadLine();
                Debug.Log(textFromFile);
                Debug.Log(textFromFile.Length);
                word.text = textFromFile;



                CharArray = word.text.ToCharArray();
                for (i = 0; i <= word.text.Length - 1; i++)
                {
                    LettersMatrix[i + 13].color = Color.white;
                    LettersMatrix[i].text = "[ ]";

                    //LettersMatrix[i+13].text = CharArray[i].ToString();

                }


            }

            WordFound = false;
            #endregion


            #region Vokal Kaufen 

            if (VokalKaufenCheck == true && score3 >= 250 && DrehungScript.AlreadyTurned == true)
            {
                OkButton.image.enabled = false;
                OkButtonTxt.enabled = false;
                Field.image.enabled = false;
                FieldTxt1.enabled = false;
                FieldTxt2.enabled = false;

                if (VokalButtonScript.onVokalClicked)
                {
                    score3 = (score3 - 250) - DrehungScript.score1;
                    letter = VokalButtonScript.Vokal;
                    LetterCheck(letter);
                    //letter = "";
                    VokalKaufenCheck = false;
                    DrehungScript.AlreadyTurned = false;

                    scoreTxt.text = "Score: " + score.ToString();
                }




                // DrehungScript.canTurn = true;
                //DrehungScript.turnisOver = true;





            }
            else if (VokalKaufenCheck == true && score < 250 && DrehungScript.AlreadyTurned == true)
            {


                OkButton.image.enabled = true;
                OkButtonTxt.enabled = true;
                Field.image.enabled = true;
                FieldTxt1.enabled = true;
                FieldTxt2.enabled = true;
                Debug.Log("Du hast nicht genug punkte um Vokale zu kaufen");

            }


            #endregion

            #region OnEnter 
            /* 
            if (Input.GetKey("return"))
            {
                DrehungScript.AlreadyTurned = false;
                letter = Field.text;
                letter = letter.ToUpper();
                if (letter == "A" || letter == "E" || letter == "I" || letter == "O" || letter == "U" || letter == "" || letter.Length > 1)
                {
                    DrehungScript.canTurn = false;
                    DrehungScript.AlreadyTurned = true;

                }
                else
                {
                    LetterCheck(letter);
                }

            }
            */
            #endregion 
        }
        #endregion

        if ( wordsCounter == 3 )
        {
            if (((score > score2 ) && (score2 > score3)) || ((score > score3) && (score3 > score2)))
            {
                GewinnSound2.Play();
                Debug.Log("player1 winss!!!");
                PlayerStatus.text = "Player 1 wins!";
                PlayerStatus.color = Color.blue;
                scoreTxt.text = score.ToString();
                RatenButton.SetActive(false);
                VokalKaufenButton.SetActive(false);
                ReturnMenuButton.SetActive(true);
                ReplayGameButton.SetActive(true);
                licht.enabled = false;
            }
            if (((score2 > score) && (score > score3)) || ((score2 > score3) && (score3 > score)))
            {
                GewinnSound2.Play();
                Debug.Log("player2 winss!!!");
                PlayerStatus.text = "Player 2 wins!";
                PlayerStatus.color = Color.red;
                scoreTxt.text = score2.ToString();
                RatenButton.SetActive(false);
                VokalKaufenButton.SetActive(false);
                ReturnMenuButton.SetActive(true);
                ReplayGameButton.SetActive(true);
                licht.enabled = false;

            }
            if (((score3 > score2) && (score2 > score) ) || ((score3 > score) && (score > score2)))
            {
                GewinnSound2.Play();
                Debug.Log("player3 winss!!!");
                PlayerStatus.text = "Player 3 wins!";
                PlayerStatus.color = Color.green;
                scoreTxt.text = score3.ToString();
                RatenButton.SetActive(false);
                VokalKaufenButton.SetActive(false);
                ReturnMenuButton.SetActive(true);
                ReplayGameButton.SetActive(true);
                licht.enabled = false;
            }

        }

    }

    public void onButtonOk2()
    {
        DrehungScript.canTurn = true;
        OkButton.image.enabled = false;
        OkButtonTxt.enabled = false;
        Field.image.enabled = false;
        FieldTxt1.enabled = false;
        FieldTxt2.enabled = false;

        if (word.text == RatenField.text.ToUpper())
        {
            wordsCounter++;
            Debug.Log("Wort ist Richtig");
            WordFound = true;
            RatenFieldGO.SetActive(false);
            OkButton2GO.SetActive(false);
            onRatenClicked = false;
            if(Player1Turn)
            {
                score = (score + 500) + DrehungScript.score1;
            }
            if (Player2Turn)
            {
                score2 = (score2 + 500) + DrehungScript.score1;
            }
            if (Player3Turn)
            {
                score3 = (score3 + 500) + DrehungScript.score1;
            }
        }
        else
        {
            Debug.Log("Wort ist Falsch");
            if (Player1Turn)
            {
                score = (score - 500 );
                if (score < 0)
                {
                    score = 0;
                }
            }
            if (Player2Turn)
            {
                score2 = (score2 - 500);
                if (score2 < 0)
                {
                    score2 = 0;
                }
            }
            if (Player3Turn)
            {
                score3 = (score3 - 500);
                if (score3 < 0)
                {
                    score3 = 0;
                }
            }
            RatenFieldGO.SetActive(false);
            OkButton2GO.SetActive(false);
            onRatenClicked = false;
            NextPlayerTurn();

        }
    }

    public void OnClickButton ()
    {
        DrehungScript.AlreadyTurned = false;
        letter = Field.text;
        letter = letter.ToUpper();
        if (letter == "A" || letter == "E" || letter == "I" || letter == "O" || letter == "U" || letter == "" || letter.Length > 1)
        {
            DrehungScript.canTurn = false;
            DrehungScript.AlreadyTurned = true;
        }
        else
        {
            LetterCheck(letter);
        }
        


   }

    public void Raten()
    {
        onRatenClicked = true;
    }

    public void VokalKaufen ()
    {
        VokalKaufenCheck = true;
       
       
        /*OkButton.image.enabled = false;
        OkButtonTxt.enabled = false;
        Field.image.enabled = false;
        FieldTxt1.enabled = false;
        FieldTxt2.enabled = false;*/
    }

    public void NextPlayerTurn()
    {
        if (Player1Turn && player3finish)
        {

            Player1Turn = false;
            Player2Turn = true;
            Player3Turn = false;
            player1finish = false;
        }

        if (Player2Turn && player1finish)
        {

            Player1Turn = false;
            Player2Turn = false;
            Player3Turn = true;
            player2finish = false;

        }

        if (Player3Turn && player2finish)
        {

            Player1Turn = true;
            Player2Turn = false;
            Player3Turn = false;
            player3finish = false;
        }
    }

    public void ReturnToMenu ()
    {
        Application.LoadLevel("Menu");
    }

    public void ReplayGame()
    {
        Application.LoadLevel("glücksrad");
    }


    void LetterCheck (string letter )
    {
        check = false;

        if (DrehungScript.canTurn == false && DrehungScript.turnisOver == false)
        {
           
            OkButton.image.enabled = false;
            OkButtonTxt.enabled = false;
            Field.image.enabled = false;
            FieldTxt1.enabled = false;
            FieldTxt2.enabled = false;
            DrehungScript.canTurn = true;
            DrehungScript.turnisOver = true;
            VokalKaufenCheck2 = false;

        }
        

        //Debug.Log("leter2" + letter);
       // Debug.Log("Word" + word.text);
       // Debug.Log(CharArray.Length);


        for (int j = 0; j <= CharArray.Length -1 ; j++)
        {
            if (CharArray[j].ToString().Contains(letter))
            {
                indexArray[LetterNumber] = j + 13;
                CharArray[j] = '*';
                LetterNumber++; // Der muss intializiert
                if (Player1Turn)
                {
                    score += DrehungScript.score1;
                }
                if (Player2Turn)
                {
                    score2 += DrehungScript.score1;
                }
                if (Player3Turn)
                {
                    score3 += DrehungScript.score1;
                }


                //Debug.Log("J === " + (j + 13));
                check = true;
               
            }
            //Debug.Log(CharArray[j].ToString());
        }

        Debug.Log(indexArray.Length);

        Debug.Log("LetterNumber " + LetterNumber);

        //chekt Ob die buchstabe sich in chararray findet

        for (int i = 0; i <= CharArray.Length; i++)
        {
            //Debug.Log("LettersMatrix[indexArray[i]]" + LettersMatrix[indexArray[i]].text);
            //Debug.Log("indexArray[i]" + indexArray[i]);
            if (LettersMatrix[indexArray[i]].text.Contains(letter))
            {
                letterAlreadyThere = true;

            }
            else
            {
                letterAlreadyThere = false;
            }
        }


        if (check && (letterAlreadyThere == false))
        {
            ApplausSound.Play();

            for (int i = 0; i < LetterNumber; i++)
            {
                numberOfletter++;
                LettersMatrix[indexArray[i]].text = letter;
            }
            Debug.Log("letterAlreadyThere" + letterAlreadyThere);
            Debug.Log("numberofletter" + numberOfletter);

            LetterNumber = 0;

            //check = false;
        }

       

        Debug.Log("Check : "+ check);
        player1finish = true;
        player2finish = true;
        player3finish = true;

        if (check)
        {
            if (Player1Turn)
            {
                Debug.Log("Player1 turn && check ");
                Player1Turn = true;
                Player2Turn = false;
                Player3Turn = false;
               // player3finish = true;
            }

            if (Player2Turn)
            {
                Debug.Log("Player2 turn && check ");
                Player1Turn = false;
                Player2Turn = true;
                Player3Turn = false;
                //player1finish = true;

            }

            if (Player3Turn)
            {
                Debug.Log("Player3 turn && check ");
                Player1Turn = false;
                Player2Turn = false;
                Player3Turn = true;
               // player2finish = true;

            }
        }

        if (check == false)
            {
            NextPlayerTurn();
            }
            


        if (numberOfletter == word.text.Length)
        {
            
            WordFound = true;
            numberOfletter = 0;
         

        }
    }

}
