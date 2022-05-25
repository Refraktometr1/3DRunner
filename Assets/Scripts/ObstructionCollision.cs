using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstructionCollision : MonoBehaviour
{
    public int dieToHitDistance;
    
    private void OnTriggerEnter(Collider other)
    {
        IDamageable target = other.GetComponent<IDamageable>();
        if (target == null)
         return;

        if (transform.position.z - other.transform.position.z > dieToHitDistance)
        {
            target.Die();
        }
        else
        {
            target.Hit();
        }
    }
}
