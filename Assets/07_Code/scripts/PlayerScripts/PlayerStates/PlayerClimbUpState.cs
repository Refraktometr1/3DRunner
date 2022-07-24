using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClimbUpState : PlayerState
{
    [SerializeField] PlayerClimb climbController;
    private string nextState;

    public override void Enter()
    {
        animator.SetBool("up", true);
        nextState = myID;
    }
    public override void Functionality()
    {

    }
    public override void Exit()
    {
        animator.SetBool("up", false);
        transform.position = climbController.currentClimbEdge.getPosition(transform.position) + transform.forward * 1.5f;
        climbController.collider.enabled = true;
    }
    public override string CheckTransitions()
    {
        return nextState;
    }

    public void ClimbUp()
    {
        nextState = "WALK";
    }
}
