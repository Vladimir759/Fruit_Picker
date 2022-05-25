using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public GameManager gameManager;
    public Text UImaxScore;
    public Text UIcurrentScore;
    public Text UItries;
    public static int score = 100;
    private int tries;
    
    private void Awake()
    {
        tries = 3;
        if(PlayerPrefs.HasKey("Max Score"))
        {
            score = PlayerPrefs.GetInt("Max Score");
            UImaxScore.text = score.ToString();
        }
        else
        {
            PlayerPrefs.SetInt("Max Score", score);
            UImaxScore.text = score.ToString();
        }      
    }

    private void Start()
    {       
        UIcurrentScore.text = "0";
        TriesUpdate();
    }

    public void AddScore(int scoreToAdd)
    {
        int tempScore = int.Parse(UIcurrentScore.text);// создать постоянное поле очков
        int tempMaxScore = int.Parse(UImaxScore.text);
        tempScore += scoreToAdd;
        if(tempScore > tempMaxScore)
        {
            PlayerPrefs.SetInt("Max Score", tempScore);
            UIcurrentScore.text = tempScore.ToString();
            UImaxScore.text = tempScore.ToString();
        }
        else
        {
            UIcurrentScore.text = tempScore.ToString();
        }              
    }

    public void TriesChange(bool isValueIncreased)
    {
        if(isValueIncreased)
        {
            tries += 1;
            TriesUpdate();
        }
        else
        {
            tries -= 1;
            TriesUpdate();
            if(tries == 0)
            {
                gameManager.RestartGame();
            }          
        }       
    }

    private void TriesUpdate()
    {
        UItries.text = tries.ToString();
    }
}
