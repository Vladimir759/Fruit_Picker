using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMover : MonoBehaviour
{
    [SerializeField] private float speed;

    private void Update()
    {
        if(transform.position.x > 65)
        {
            transform.position = new Vector3(-65, transform.position.y, transform.position.z);
        }
        transform.position += Vector3.right * speed * Time.deltaTime;
    }
}
