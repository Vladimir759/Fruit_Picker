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
        _audioSource.clip = fruitCollected;
        _audioSource.Play();
        Destroy(gameObject, 0.15f);
    }

    public override void ObjectSkipped()
    {
        GameManager gameManager = Camera.main.GetComponent<GameManager>();
        _audioSource.clip = destroySound;
        _audioSource.Play();
        //задержка
        gameManager.DestroyAllDroppedObjects();
    }






}
