using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    public float speed;
    private Rigidbody _missileRB;

    private void Start()
    {
        _missileRB = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        _missileRB.velocity = transform.up * speed;
    }
}
