using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DropObjectType
{
    Fruit,
    Bomb,
    WormedFruit
}

public abstract class DropableObject : MonoBehaviour
{
    protected AudioSource audioSource;
    [SerializeField] protected AudioClip appearanceSound, destroySound;
    protected float YposLimit = -18f;
    protected Rigidbody rb;

    protected void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
    }

    protected void Start()
    {
        audioSource.clip = appearanceSound;
        audioSource.Play();
    }

    protected void Update()
    {
        if(transform.position.y < YposLimit)
        {
            ObjectSkipped();
        }
        Debug.Log(rb.velocity.y);
    }

    public abstract void ObjectSkipped();

    public abstract void ObjectCollected();

    protected void OnDisable()
    {
        rb.velocity = Vector3.zero;
    }
}
