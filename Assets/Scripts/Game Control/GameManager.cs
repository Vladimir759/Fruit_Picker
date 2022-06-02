using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public FruitSpowner fruitBoxScript;
    public ScoreScript scoreScript;
    public Basket basketScript;

    private bool gameRunning;
    private int levelDifficulty = 0;

    public static int gameStage = 0;

    private void Awake()
    {
        gameRunning = true;
        Debug.Log(gameRunning);
    }


    public void DestroyAllDroppedObjects()
    {
        GameObject[] objectsInScene = GameObject.FindGameObjectsWithTag("Dropped");
        foreach (var droppedObj in objectsInScene)
        {
            Destroy(droppedObj);           
        }
        scoreScript.TriesChange(false); 
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void GameOver()
    {
        gameStage = 2;
        //ui info/control off
        //spowner on
        //ui show result
        //Insects applauds
    }

    public void PauseGame()
    {
        if(gameRunning)
        {
            Time.timeScale = 0f;
            gameRunning = !gameRunning;
        }
        else
        {
            Time.timeScale = 1f;
            gameRunning = !gameRunning;
        }
    }

    public void IncreaseDifficultyLevel()
    {    
        Debug.Log("Difficulty Up");
        levelDifficulty++;
        switch (levelDifficulty)
        {
            case 1:
                fruitBoxScript.AddNewDropItem();//bomb
                scoreScript.TriesChange(true);
                scoreScript.nextDifficultScore = 100;
                break;
            case 2:
                fruitBoxScript.AddNewDropItem();//pineapple
                fruitBoxScript.AddNewDropItem();//green Worm Apple
                scoreScript.TriesChange(true);
                scoreScript.nextDifficultScore = 300;
                gameStage = 1;//сомнительно
                break;
            case 3:
                //activate Fly Spowner
                fruitBoxScript.AddNewDropItem();//wormApple
                scoreScript.TriesChange(true);
                scoreScript.nextDifficultScore = 500;
                break;
            case 4:
                fruitBoxScript.AddNewDropItem();//watermelon
                //activate Bug Spowner
                scoreScript.TriesChange(true);
                scoreScript.nextDifficultScore = 800;
                break;
            case 5:
                fruitBoxScript.AddNewDropItem();//melon
                scoreScript.TriesChange(true);
                break;
        }
    }

}
