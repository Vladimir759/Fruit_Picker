using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public FruitSpowner fruitBoxScript;
    public ScoreScript scoreScript;
    public Basket basketScript;

    [SerializeField] private Text finalScore;
    [SerializeField] private GameObject infoUI;
    [SerializeField] private GameObject controlGroup;
    [SerializeField] private GameObject resultPanel;
    [SerializeField] private GameObject restartPanel;
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private GameObject flySpowner;
    [SerializeField] private GameObject stage;
    [SerializeField] private GameObject fruitBox, basket;

    private bool gameRunning;
    private int levelDifficulty = 0;

    public static int gameStage = 1;

    private void Awake()
    {
        gameStage = 1;
        gameRunning = true;
    }

    /*private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && gameStage == 1)
        {
            PauseGame();
        }
    }*/

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

    public IEnumerator ShowResult()
    {                       
        stage.SetActive(true);
        finalScore.text = scoreScript.currentScore.ToString();
        resultPanel.SetActive(true);
        yield return new WaitForSeconds(4);
        restartPanel.SetActive(true);
        //start particle System
        
    }


    public void GameOver()
    {
        gameStage = 2;      
        infoUI.SetActive(false);
        controlGroup.SetActive(false);
        GameObject[] flyObjects = GameObject.FindGameObjectsWithTag("FlyingObject");
        foreach (var obj in flyObjects)
        {
            Destroy(obj);
        }
        Destroy(fruitBox);
        Destroy(basket);
        StartCoroutine(ShowResult());
    }

    public void PauseGame()
    {
        if(gameRunning)
        {
            Time.timeScale = 0f;
            gameRunning = !gameRunning;
            settingsPanel.SetActive(true);
        }
        else
        {
            Time.timeScale = 1f;
            gameRunning = !gameRunning;
            settingsPanel.SetActive(false);
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
                fruitBoxScript.secondsBetweenDrops = 0.95f;
                break;
            case 3:
                flySpowner.SetActive(true);
                fruitBoxScript.AddNewDropItem();//wormApple
                scoreScript.TriesChange(true);
                scoreScript.nextDifficultScore = 500;
                fruitBoxScript.secondsBetweenDrops = 0.9f;
                break;
            case 4:
                fruitBoxScript.AddNewDropItem();//watermelon
                //activate Bug Spowner
                scoreScript.TriesChange(true);
                scoreScript.nextDifficultScore = 800;
                fruitBoxScript.secondsBetweenDrops = 0.85f;
                break;
            case 5:
                fruitBoxScript.AddNewDropItem();//melon
                scoreScript.TriesChange(true);
                break;
        }
    }

    public void Exit()
    {
        Application.Quit();
    }

}
