using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FXPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip fruitCollected, littleFruitCrash, bigFruitCrash, bombExplosion, wormedFruitCollected;

    public void PlayFruitCollected()
    {
        audioSource.clip = fruitCollected;
        audioSource.Play();
    }

    public void PlayFruitSkiped(bool fruitIsBig)//fruit skiped
    {
        audioSource.clip = fruitIsBig ? bigFruitCrash : littleFruitCrash;
        audioSource.Play();
    }
    
    public void PlayEnemyObjectCollected(DropObjectType type)
    {
        //audioSource.clip = type
    }

}
