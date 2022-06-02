using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Basket : MonoBehaviour
{
    //public ScoreScript scoreScript;
    public MeshRenderer _meshRender;
    private const float _blinkDelay = 0.1f;
    //private float _speed;
    private float speed = 30f;

    

    private void Start()
    {       
        _meshRender = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.A) && transform.position.x > -18.1f)//для тестирования
        {
            Vector3 pos = transform.position;
            pos.x -= speed * Time.deltaTime;
            transform.position = pos;
        }
        else if(Input.GetKey(KeyCode.D) && transform.position.x < 18.1f)
        {
            Vector3 pos = transform.position;
            pos.x += speed * Time.deltaTime;
            transform.position = pos;
        }
       
        /*if (Input.GetKeyDown(KeyCode.E))//для тестирования
        {
            StartCoroutine(BasketBlink());
        }*/

        //BasketMover();
    }

    

    public void OnCollisionEnter(Collision collision)
    {
        GameObject collidedObj = collision.gameObject;
        var objectComfirmed = collidedObj.GetComponent<DropableObjectTemplate>();
        if(objectComfirmed != null)
        {
            objectComfirmed.ObjectCollected();
        }
    }
     
    public IEnumerator BasketBlink()
    {       
        for (int i = 0; i < 6; i++)
        {
            _meshRender.enabled = !_meshRender.enabled;
            yield return new WaitForSeconds(_blinkDelay);
            Debug.Log("Basket blink");
        }
    }

    public void BasketMover()
    {
        if(transform.position.x < 23f && transform.position.x > -23f)
        {
            Vector3 pos = transform.position;
            pos.x += speed * Time.deltaTime;
            transform.position = pos;
            Debug.Log(speed);
        }
    }

    public void RightButtonDown()
    {
        //speed = 30;
    }

    public void LeftButtonDown()
    {
        //speed = -30f;
    }

    public void ButtonUp()
    {
        //speed = 0f;       
    }
}
