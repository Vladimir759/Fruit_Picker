using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameStates
{
    GameInProgress = 1,
    GameOver = 2
}

public class GameManager : MonoBehaviour
{ 
    [SerializeField] private ScoreScript scoreScript;
    [SerializeField] private Basket basketScript;
    [SerializeField] private Text finalScore;
    [SerializeField] private GameObject infoUI;
    [SerializeField] private GameObject controlGroup;
    [SerializeField] private GameObject resultPanel;
    [SerializeField] private GameObject restartPanel;
    [SerializeField] private GameObject settingsPanel;   
    [SerializeField] private GameObject stage;
    [SerializeField] private GameObject objectsSpawner, basket;
    private GameStates gameState;
    private bool gameRunning;

    public GameStates GameState
    {
        get { return gameState; }
    }

    private void Awake()
    {
        gameState = GameStates.GameInProgress;
        gameRunning = true;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void PauseGame()
    {
        if (gameRunning)
        {
            Time.timeScale = 0f;
            gameRunning = false;
            settingsPanel.SetActive(true);
        }
        else
        {
            Time.timeScale = 1f;
            gameRunning = true;
            settingsPanel.SetActive(false);
        }
    }

    public void GameOver()
    {
        gameState = GameStates.GameOver;  
        infoUI.SetActive(false);
        controlGroup.SetActive(false);
        FlyingObjectTemplate[] flyObjects = FindObjectsOfType<FlyingObjectTemplate>();
        foreach (var obj in flyObjects)
        {
            obj.gameObject.SetActive(false);
        }
        Destroy(objectsSpawner);
        Destroy(basket);
        StartCoroutine(ShowResult());
    }

    public IEnumerator ShowResult()
    {
        stage.SetActive(true);
        finalScore.text = scoreScript.CurrentScore.ToString();
        resultPanel.SetActive(true);
        yield return new WaitForSeconds(4);
        restartPanel.SetActive(true);
        //start particle System     
    }

    public void Exit()
    {
        Application.Quit();
    }
}
