using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyObject : DropableObjectTemplate
{
    public override void ObjectCollected()
    {
        ScoreScript scoreScript = Camera.main.GetComponent<ScoreScript>();
        scoreScript.TriesChange(false);
        _audioSource.clip = destroySound;
        _audioSource.Play();
        Destroy(gameObject, 0.17f);
    }

    public override void ObjectSkipped()
    {
        Destroy(gameObject);
    }
}
