using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallClimbState : PlayerState
{
    [SerializeField] private PlayerClimb climbController;
    [SerializeField] private float gravityPower;

    private ClimbController startController;
    private bool climbSurfaceDownMe;
    private bool climbSurfaceTriggered;
    public bool fallAfterJump = false;

    public override void Enter()
    {
        climbSurfaceTriggered = false;
        controller.enabled = false;
        animator.SetFloat("speed", 0.0f);
        animator.SetBool("climb", true);
        startController = climbController.currentClimbEdge;
        climbController.collider.enabled = true;
    }
    public override void Functionality()
    {
        transform.Translate(Vector3.down * gravityPower * Time.deltaTime);
        if(!climbSurfaceDownMe) climbSurfaceDownMe = CheckClimbGround();
    }
    public override void Exit()
    {
        climbSurfaceDownMe = false;
        fallAfterJump = false;
        animator.SetBool("climb", false);
    }

    public override string CheckTransitions()
    {
        if (climbController.currentClimbEdge.GetInstanceID() != startController.GetInstanceID()
            || (climbSurfaceTriggered && fallAfterJump))
        {
            return "CLIMB";
        }
        else if(GroundCheck(0.1f))
        {
            return "WALK";
        }
        else
        {
            return myID;
        }
    }

    private bool CheckClimbGround()
    {
        RaycastHit hit;
        float distance = 0.1f;
        Physics.Raycast(transform.position, Vector3.down, out hit, distance);
        if (hit.collider != null)
        {
            return hit.collider.gameObject.tag == "Climb";
        }
        else
        {
            return false;
        }
    }

    public void ClimbSurfaceTriggered()
    {
        climbSurfaceTriggered = true;
    }
}
