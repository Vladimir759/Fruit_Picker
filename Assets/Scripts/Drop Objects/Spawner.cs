using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private float movingSpeed = 1f;
    private float chanceToChangeDirection = 0.1f;
    private float screenPositionLimit = 18f;

    private void Update()
    {
        Vector3 pos = transform.position;
        pos.x += movingSpeed * Time.deltaTime;
        transform.position = pos;

        if (pos.x > screenPositionLimit || pos.x < -screenPositionLimit)
        {
            movingSpeed *= -1;
        }
    }

    private void FixedUpdate()
    {
        if (Random.value < chanceToChangeDirection)
        {
            movingSpeed *= -1;
            Debug.Log("Direction Inverted");
        }
    }
}
