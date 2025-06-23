using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketMoverPC : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float basketPositionLimit = 23;
    private float horizInput;
    
    void Update()
    {
        horizInput = Input.GetAxisRaw("Horizontal");
        Vector3 tempPos = transform.position;
        tempPos.x += horizInput * speed * Time.deltaTime;
        tempPos.x = Mathf.Clamp(tempPos.x, -basketPositionLimit, basketPositionLimit);
        transform.position = tempPos;
        Debug.Log(speed);

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //PauseGame();
        }
    }
}
