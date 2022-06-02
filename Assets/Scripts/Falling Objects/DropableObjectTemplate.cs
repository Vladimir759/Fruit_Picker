using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DropableObjectTemplate : MonoBehaviour
{
    public AudioSource _audioSource;
    public AudioClip appearanceSound, destroySound;

    public void Awake()
    {
        _audioSource = GetComponent<AudioSource>();       
    }

    public void Start()
    {
        _audioSource.clip = appearanceSound;
        _audioSource.Play();
    }

    public void Update()
    {
        if(transform.position.y < -20f)
        {
            ObjectSkipped();
        }
    }

    public abstract void ObjectSkipped();

    public abstract void ObjectCollected();

}
