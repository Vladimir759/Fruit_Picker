using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FlyingObjectTemplate : MonoBehaviour
{   
    public Transform deletePoint;
    public Vector3 flyDestination;

    public Animator _animator;
    public AnimationClip targetClip;

    public AudioSource _audioSource;
    public AudioClip flying, leaving, applause;

    public float XposLimit = 24f;
    public float topYposLimit = 11f;
    public float bottomYposLimit = -7f;
    public float flySpeed = 10f;
    public float rotateSpeed = 10f;

    public int timesBeforeLeftScreen = 5;

    public void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
        _audioSource = GetComponent<AudioSource>();
    }

    public void Start()
    {
        if(GameManager.gameStage == 1)
        {
            _animator.SetInteger("flyAnim", 1);
        }
        else
        {
            Invoke(nameof(ChangeAnimation), 2);
        }
    }

    public void Update()
    {
        if (GameManager.gameStage == 2) return;
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(flyDestination), rotateSpeed * Time.deltaTime);
        transform.position = Vector3.MoveTowards(transform.position, flyDestination, flySpeed * Time.deltaTime);
        if (transform.position == flyDestination)
        {
            ChangePosition();
        }

        if (transform.position == deletePoint.position)
        {
            Destroy(gameObject);
        }
    }

    public abstract void ChangePosition();
    public abstract void ChangeAnimation();
    public abstract void TakeDamage(int damage);
}
