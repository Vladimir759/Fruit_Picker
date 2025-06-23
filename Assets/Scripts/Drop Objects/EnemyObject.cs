using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyObject : DropableObject
{
    public override void ObjectCollected()
    {
        GameplayController gameplayController = Camera.main.GetComponent<GameplayController>();
        gameplayController.DisableEnemyObject(gameObject, false);
        audioSource.clip = destroySound;
        audioSource.Play();
    }

    public override void ObjectSkipped()
    {
        GameplayController gameplayController = Camera.main.GetComponent<GameplayController>();
        gameplayController.DisableEnemyObject(gameObject, true);
    }
}
