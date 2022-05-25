using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    private void Update()
    {
        if(transform.position.y <= -20)
        {
            Destroy(gameObject);
        }
    }
}
