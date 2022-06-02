using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fly : FlyingObjectTemplate
{

    
    public override void ChangePosition()
    {
        if(timesBeforeLeftScreen > 0)
        {
            flyDestination = new Vector3 (Random.Range(-XposLimit, XposLimit), Random.Range(bottomYposLimit, topYposLimit), 0f);
            timesBeforeLeftScreen--;
        }
        else
        {
            flyDestination = deletePoint.position;
        }      
    }

    public override void ChangeAnimation()
    {
        _animator.SetInteger("flyAnim", 2);
    }

    public override void TakeDamage(int damage)
    {
        timesBeforeLeftScreen -= damage;
        ChangePosition();
    }
}
