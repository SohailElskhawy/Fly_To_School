using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManeger : MonoBehaviour
{

    public Text scoreTxt;
    public static float theScore;
    public Text highScoreTxt;
    private float theHighScore;
    
    public Text highScoreTxtM;
    public Text scoreGOtxt;
    public Text hiScoreGOtxt;
    public Text resultGo;

    public float scoreSpeed = 10f;
    


    
    
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        theScore = 0f;
        theHighScore = PlayerPrefs.GetFloat("HighScore", theHighScore);
        highScoreTxtM.text = "Highscore : " +  ((int)theHighScore).ToString();
        scoreSpeed = 10f;
    }

    // Update is called once per frame
    void Update()
    {
       if(GameObject.FindGameObjectWithTag("Player") != null)
        {
            theScore += scoreSpeed * Time.deltaTime;
            scoreTxt.text = ((int)theScore).ToString();
        }

        highScoreTxt.text = ((int)theHighScore).ToString();

        if(theScore > theHighScore)
        {
            PlayerPrefs.SetFloat("HighScore", theScore);
            PlayerPrefs.Save();
            hiScoreGOtxt.text = "Highscore : " +  ((int)theScore).ToString();
            resultGo.text = "New Score!!";
        }
        else
        {
            hiScoreGOtxt.text = "Highscore : " +  ((int)theHighScore).ToString();
            resultGo.text = "GameOver!";
        }

        scoreGOtxt.text = "Score : " +  ((int)theScore).ToString();
        

    }

}
