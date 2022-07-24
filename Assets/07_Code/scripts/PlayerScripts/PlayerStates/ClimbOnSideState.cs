using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbOnSideState : PlayerState
{
    [SerializeField] private PlayerClimb climbController;
    [SerializeField] private float gravityPower;

    [SerializeField] private float jumpPower;
    private float currentJump;

    private ClimbController startController;

    public override void Enter()
    {
        currentJump = jumpPower;
        controller.enabled = false;
        animator.SetFloat("speed", 0.0f);
        animator.SetBool("climb", true);
        startController = climbController.currentClimbEdge;
        climbController.collider.enabled = true;
    }
    public override void Functionality()
    {
        currentJump -= gravityPower * Time.deltaTime;
        transform.Translate(Vector3.up * currentJump * Time.deltaTime);
    }
    public override void Exit()
    {
        animator.SetBool("climb", false);
    }

    public override string CheckTransitions()
    {
        Debug.LogFormat("Current: {0}", climbController.currentClimbEdge.GetInstanceID());
        Debug.LogFormat("Start: {0}", startController.GetInstanceID());
        if (climbController.currentClimbEdge.GetInstanceID() != startController.GetInstanceID())
        {
            return "CLIMB";
        }
        else if (currentJump < 0)
        {
            return "CLIMB_FALL";
        }
        else
        {
            return myID;
        }
    }
}
