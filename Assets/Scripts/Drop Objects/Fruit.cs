using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : DropableObjectTemplate
{
    
    public AudioClip fruitCollected;
    public int scoreReward;
    //public int hitPower;


    public override void ObjectCollected()
    {
        ScoreScript scoreScipt = Camera.main.GetComponent<ScoreScript>();
        scoreScipt.AddScore(scoreReward);
        audioSource.clip = fruitCollected;
        audioSource.Play();
        Destroy(gameObject, 0.1f);
    }

    public override void ObjectSkipped()
    {
        GameManager gameManager = Camera.main.GetComponent<GameManager>();
        audioSource.clip = destroySound;
        audioSource.Play();
        //задержка
        gameManager.DestroyAllDroppedObjects();
    }






}
