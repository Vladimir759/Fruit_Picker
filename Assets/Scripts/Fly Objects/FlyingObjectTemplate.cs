using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FlyingObjectTemplate : MonoBehaviour
{   
    [SerializeField] protected Vector3 flyDestination;
    protected Animator animator;
    protected AudioSource audioSource;
    [SerializeField] protected AudioClip flying, leaving, applause;

    public float XposLimit = 24f;
    public float topYposLimit = 11f;
    public float bottomYposLimit = -7f;
    public float flySpeed = 10f;
    public float rotateSpeed = 10f;

    protected int timesBeforeLeftScreen = 5;

    public void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        audioSource = GetComponent<AudioSource>();      
    }

    public void Start()
    {
        if(GameManager.gameStage == 1)
        {
            animator.SetInteger("flyAnim", 1);
            audioSource.clip = flying;
            audioSource.loop = true;
            audioSource.Play();
        }
        else
        {
         
            Invoke(nameof(ChangeAnimation), 2f);
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
    }

    public abstract void ChangePosition();
    public abstract void ChangeAnimation();
    public abstract void TakeDamage(int damage);
}
