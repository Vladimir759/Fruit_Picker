using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyObject : DropableObjectTemplate
{
    public override void ObjectCollected()
    {
        ScoreScript scoreScript = Camera.main.GetComponent<ScoreScript>();
        scoreScript.TriesChange(false);
        audioSource.clip = destroySound;
        audioSource.Play();
        Destroy(gameObject, 0.15f);
    }

    public override void ObjectSkipped()
    {
        Destroy(gameObject);
    }
}
