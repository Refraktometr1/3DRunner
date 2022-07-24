using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : State
{
    protected CharacterController controller;
    protected Animator animator;
    protected PlayerStateController mainController;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        mainController = GetComponent<PlayerStateController>();
    }

    protected bool GroundCheck(float distance)
    {
        RaycastHit hit;
        Physics.Raycast(transform.position, Vector3.down, out hit, distance);
        return hit.collider != null ? hit.collider.gameObject.tag != "LookZone" : false;
    }
}
