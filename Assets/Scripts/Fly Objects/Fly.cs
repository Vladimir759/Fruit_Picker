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
            flyDestination = new Vector3(40,0,0);
            audioSource.pitch = 0.8f;
        }      
    }

    public override void ChangeAnimation()
    {
        animator.SetInteger("flyAnim", 2);
        audioSource.clip = applause;
        audioSource.loop = true;
        audioSource.pitch = 1.0f;
        audioSource.Play();
    }

    public override void TakeDamage(int damage)//пока не нужен
    {
        timesBeforeLeftScreen -= damage;
        ChangePosition();
    }
}
