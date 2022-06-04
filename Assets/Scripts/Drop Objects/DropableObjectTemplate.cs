using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DropableObjectTemplate : MonoBehaviour
{
    protected AudioSource audioSource;
    [SerializeField] protected AudioClip appearanceSound, destroySound;

    public void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void Start()
    {
        audioSource.clip = appearanceSound;
        audioSource.Play();
    }

    public void Update()
    {
        if(transform.position.y < -18f)
        {
            ObjectSkipped();
        }
    }

    public abstract void ObjectSkipped();

    public abstract void ObjectCollected();

}
