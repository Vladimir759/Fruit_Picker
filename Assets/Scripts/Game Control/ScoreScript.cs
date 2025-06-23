using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    private const int START_TRIES = 3;
    private const int DEFAULT_NEXT_DIFFICULT_SCORE = 50;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private GameplayController gameplayController;
    [SerializeField] private Basket basketScript;
    [SerializeField] private Text UImaxScore;
    [SerializeField] private Text UIcurrentScore;
    [SerializeField] private Text UItries;
    private int scoreDefault = 100;
    private int currentScore;
    private int maxScore;
    private int tries;
    private int nextDifficultScore;

    public int CurrentScore
    {
        get { return currentScore; }
    }

    private void Awake()
    {
        tries = START_TRIES;
        nextDifficultScore = DEFAULT_NEXT_DIFFICULT_SCORE;
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
        UpdateTriesInfo();
    }

    public void AddScore(int scoreToAdd)
    {
        currentScore += scoreToAdd;
        if(currentScore >= nextDifficultScore)
        {
            gameplayController.IncreaseDifficultyLevel();
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
            UpdateTriesInfo();
        }
        else
        {
            Debug.Log(tries);
            tries -= 1;
            UpdateTriesInfo();
            if(tries == 0)
            {
                gameManager.GameOver();
            }          
        }       
    }

    public void UpdateNextDifficultScore(int newValue)
    {
        nextDifficultScore = Mathf.Abs(newValue);
    }

    private void UpdateTriesInfo()
    {
        UItries.text = tries.ToString();
    }
}
