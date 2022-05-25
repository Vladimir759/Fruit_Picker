using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Basket : MonoBehaviour
{
    public ScoreScript scoreScript;
    public MeshRenderer basketVis;
    private const float blinkDelay = 0.1f;
    private float moveSpeed = 30f;
    private float speed;

    private void Awake()
    {
        scoreScript = GameObject.Find("Canvas").GetComponent<ScoreScript>();
        FindObjectOfType<GameManager>().basketScript = this;

    }

    void Start()
    {       
        basketVis = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        /*if(Input.GetKey(KeyCode.A) && transform.position.x > -18.1f)//для тестирования
        {
            Vector3 pos = transform.position;
            pos.x -= moveSpeed * Time.deltaTime;
            transform.position = pos;
        }
        else if(Input.GetKey(KeyCode.D) && transform.position.x < 18.1f)
        {
            Vector3 pos = transform.position;
            pos.x += moveSpeed * Time.deltaTime;
            transform.position = pos;
        }
       
        if (Input.GetKeyDown(KeyCode.E))//для тестирования
        {
            StartCoroutine(BasketBlink());
        }*/

        BasketMover();
    }

    

    private void OnCollisionEnter(Collision collision)
    {
        GameObject collidedObj = collision.gameObject;
        if(collidedObj.CompareTag("Fruit"))
        {
            int reward = collidedObj.GetComponent<Fruit>().scoreReward;
            scoreScript.AddScore(reward);
            Destroy(collidedObj);                    
        }
        else if(collidedObj.CompareTag("Enemy"))
        {
            Destroy(collidedObj);
            StartCoroutine(BasketBlink());
            scoreScript.TriesChange(false);
        }
    }
     
    public IEnumerator BasketBlink()
    {       
        for (int i = 0; i < 6; i++)
        {
            basketVis.enabled = !basketVis.enabled;
            yield return new WaitForSeconds(blinkDelay);
            Debug.Log("Basket blink");
        }
    }

    public void BasketMover()
    {
        if(transform.position.x < 18.1f && transform.position.x > -18.1f)
        {
            Vector3 pos = transform.position;
            pos.x += speed * Time.deltaTime;
            transform.position = pos;
            Debug.Log(speed);
        }
    }

    public void RightButtonDown()
    {
        speed = 30f;
        Debug.Log(speed);
    }

    public void LeftButtonDown()
    {
        speed = -30f;
        Debug.Log(speed);
    }

    public void ButtonUp()
    {
        speed = 0f;       
    }

}
