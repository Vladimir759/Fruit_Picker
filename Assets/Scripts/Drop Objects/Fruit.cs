using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : DropableObject
{
    [SerializeField] private bool isBig;
    public AudioClip fruitCollected;
    public int scoreReward;
    //public int hitPower;

    public override void ObjectCollected()
    {
        GameplayController gameplayController = Camera.main.GetComponent<GameplayController>();
        gameplayController.PlayerCollectedFruit(scoreReward, gameObject);
        audioSource.clip = fruitCollected;
        audioSource.Play();
    }

    public override void ObjectSkipped()
    {
        GameplayController gameplayController = Camera.main.GetComponent<GameplayController>();
        audioSource.clip = destroySound;
        audioSource.Play();
        gameplayController.PlayerMissedFruit(gameObject);
    }
}
