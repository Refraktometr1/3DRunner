using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : SimplePathMoveTriggered
{

    private CharacterController player;
    private bool playerOnPlatform = false;

    void Update()
    {
        if(isMoving)
        {
            Vector3 delta = MoveToTarget();
            if (playerOnPlatform) player.Move(delta - transform.position);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        playerOnPlatform = other.gameObject.tag == "Player";
    }

    private void OnTriggerExit(Collider other)
    {
        playerOnPlatform = !(other.gameObject.tag == "Player");
    }
}
