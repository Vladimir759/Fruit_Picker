using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Basket : MonoBehaviour
{

    public void OnCollisionEnter(Collision collision)
    {
        GameObject collidedObj = collision.gameObject;
        var objectComfirmed = collidedObj.GetComponent<DropableObject>();
        if(objectComfirmed != null)
        {
            objectComfirmed.ObjectCollected();
        }
    }
}
