using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayController : MonoBehaviour
{
    [SerializeField] private SpawnManager spawnManager;
    [SerializeField] private ScoreScript scoreScript;
    [SerializeField] private GameObject flySpowner;
    private int levelDifficulty = 0;
    private float spawnDelayDecreaseTime = 0.05f;

    public void IncreaseDifficultyLevel()
    {
        Debug.Log("Difficulty Up");
        levelDifficulty++;
        switch (levelDifficulty)
        {
            case 1:
                spawnManager.AddNewDropItem((int)SpawnObjects.Bomb);//add bomb
                scoreScript.TriesChange(true);
                scoreScript.UpdateNextDifficultScore(100);
                break;
            case 2:
                spawnManager.AddNewDropItem((int)SpawnObjects.Bomb);//add bomb
                spawnManager.AddNewDropItem((int)SpawnObjects.Pineapple);//add pineapple
                spawnManager.AddNewDropItem((int)SpawnObjects.GreenWormApple);//add green Worm Apple drop & worm applaude
                scoreScript.TriesChange(true);
                scoreScript.UpdateNextDifficultScore(300);
                spawnManager.SecondsBetweenDrops -= spawnDelayDecreaseTime;
                break;
            case 3:
                flySpowner.SetActive(true);
                spawnManager.AddNewDropItem((int)SpawnObjects.RedWormApple);//add red wormApple 
                scoreScript.TriesChange(true);
                scoreScript.UpdateNextDifficultScore(500);
                spawnManager.SecondsBetweenDrops -= spawnDelayDecreaseTime;
                break;
            case 4:
                spawnManager.AddNewDropItem((int)SpawnObjects.Watermelon);//watermelon
                //activate Bug Spowner
                scoreScript.TriesChange(true);
                scoreScript.UpdateNextDifficultScore(800);
                spawnManager.SecondsBetweenDrops -= spawnDelayDecreaseTime;
                break;
            case 5:
                spawnManager.AddNewDropItem((int)SpawnObjects.Melon);//melon
                scoreScript.TriesChange(true);
                spawnManager.SecondsBetweenDrops -= spawnDelayDecreaseTime;
                break;
        }
    }

    public void PlayerCollectedFruit(int score, GameObject collectedFruit)
    {
        scoreScript.AddScore(score);
        spawnManager.ReturnToDropList(collectedFruit);
    }

    public void PlayerMissedFruit(GameObject missedFruit)
    {
        spawnManager.DisableAllDropedObjects();
        scoreScript.TriesChange(false);
    }

    public void DisableEnemyObject(GameObject enemyObject, bool playerAvoided)
    {
        spawnManager.ReturnToDropList(enemyObject);
        if(playerAvoided)
        {
            return;
        }
        else
        {
            scoreScript.TriesChange(false);
        }
        
    }
}
