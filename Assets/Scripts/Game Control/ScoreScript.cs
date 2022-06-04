using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public GameManager gameManager;
    public Basket basketScript;
    [SerializeField] private Text UImaxScore;
    [SerializeField] private Text UIcurrentScore;
    [SerializeField] private Text UItries;
    private int scoreDefault = 100;
    public int currentScore;
    private int maxScore;
    private int tries;
    public int nextDifficultScore;
    
    private void Awake()
    {
        tries = 3;
        nextDifficultScore = 50;
        if(PlayerPrefs.HasKey("Max Score"))
        {
            maxScore = PlayerPrefs.GetInt("Max Score");
            UImaxScore.text = maxScore.ToString();
        }
        else
        {
            PlayerPrefs.SetInt("Max Score", scoreDefault);
            maxScore = scoreDefault;
            UImaxScore.text = scoreDefault.ToString();
        }      
    }

    private void Start()
    {       
        UIcurrentScore.text = "0";
        TriesUpdate();
    }

    public void AddScore(int scoreToAdd)
    {
        currentScore += scoreToAdd;
        if(currentScore >= nextDifficultScore)
        {          
            gameManager.IncreaseDifficultyLevel();
        }

        if(currentScore > maxScore)
        {
            PlayerPrefs.SetInt("Max Score", currentScore);
            UIcurrentScore.text = currentScore.ToString();
            UImaxScore.text = currentScore.ToString();
        }
        else
        {
            UIcurrentScore.text = currentScore.ToString();
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
            Debug.Log(tries);
            tries -= 1;
            TriesUpdate();
            if(tries == 0)
            {
                gameManager.GameOver();
                //gameManager.StartGame();
            }          
        }       
    }

    private void TriesUpdate()
    {
        UItries.text = tries.ToString();
    }
}
