using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FlyingObjectTemplate : MonoBehaviour
{
    [SerializeField] protected GameManager gameManager;
    [SerializeField] protected Vector3 flyDestination;
    [SerializeField] protected AudioClip flying, leaving, applause, hello;
    [SerializeField] protected float flySpeed;//change
    [SerializeField] protected int timesBeforeLeftScreen;//change
    [SerializeField] protected float rotateSpeed;//change

    protected AudioSource audioSource;
    protected float XposLimit = 24f;
    protected float topYposLimit = 11f;
    protected float bottomYposLimit = -7f;
    
    
    

    public void Awake()
    {
        gameManager = Camera.main.GetComponent<GameManager>();
        audioSource = GetComponent<AudioSource>();      
    }

    public void Start()
    {
        if(gameManager.GameState == GameStates.GameInProgress)
        {
            audioSource.clip = flying;
            audioSource.loop = true;
            audioSource.Play();
        }
    }

    public void Update()
    {
        if (gameManager.GameState == GameStates.GameOver) return;
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(flyDestination), rotateSpeed * Time.deltaTime);
        transform.position = Vector3.MoveTowards(transform.position, flyDestination, flySpeed * Time.deltaTime);
        if (transform.position == flyDestination)
        {
            ChangePosition();
        }
    }

    public abstract void ChangePosition();
}
