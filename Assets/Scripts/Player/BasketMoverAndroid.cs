using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketMoverAndroid : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float basketPositionLimit = 23;

    private void Update()
    {
        MoveBasket();
    }

    private void MoveBasket()
    {      
        Vector3 tempPos = transform.position;
        tempPos.x += speed * Time.deltaTime;
        tempPos.x = Mathf.Clamp(tempPos.x, -basketPositionLimit, basketPositionLimit);
        transform.position = tempPos;
        Debug.Log(speed);       
    }

    public void RightButtonDown()
    {
        speed *= 1;
    }

    public void LeftButtonDown()
    {
        speed *= -1;
    }

    public void ButtonUp()
    {
        speed = 0f;
    }
}
