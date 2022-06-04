using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityCube : MonoBehaviour
{   
    private void FixedUpdate() 
    {
        transform.Rotate(0.2f, -0.2f, -0.2f);
    }
}
