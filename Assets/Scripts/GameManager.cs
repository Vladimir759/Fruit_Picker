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
    public GameObject basketPref;

    //private int levelDifficulty;

    private void Awake()
    {
        Time.timeScale = 1f;
        //levelDifficulty = 1;
    }

    private void Start()
    {
        GameObject basket = Instantiate<GameObject>(basketPref);
        Vector3 targetPos = Vector3.zero;
        targetPos.y = -14f;
        basket.transform.position = targetPos;
    }

    public void DestroyAllFruits()
    {
        GameObject[] fruitsInScene = GameObject.FindGameObjectsWithTag("Fruit");
        foreach (var fruit in fruitsInScene)
        {
            Destroy(fruit);           
        }
        scoreScript.TriesChange(false);
        StartCoroutine(basketScript.BasketBlink());
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void PauseGame()
    {
        if(Time.timeScale == 1f)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }

    public void IncreaseDifficultyLevel()
    {

    }

}
