using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Basket : MonoBehaviour
{
    private float speed = 30f;


    private void Update()
    {
        if(Input.GetKey(KeyCode.A) && transform.position.x > -18.1f)//для тестирования
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
 
        }
        else if(Input.GetKey(KeyCode.D) && transform.position.x < 18.1f)
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }

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
