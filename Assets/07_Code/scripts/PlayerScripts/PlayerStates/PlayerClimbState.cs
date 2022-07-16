using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClimbState : PlayerState
{
    [SerializeField] private PlayerClimb climbController;
    [SerializeField] private float horizontalClimbSpeed;

    private bool onJump = false;

    public override void Enter()
    {
        controller.enabled = false;
        animator.SetFloat("speed", 0.0f);
        animator.SetBool("climb", true);
        transform.rotation = climbController.currentClimbEdge.transform.rotation;
        transform.position = climbController.currentClimbEdge.getPosition(transform.position) + new Vector3(0, -2f, 0);
        climbController.collider.enabled = false;
    }
    public override void Functionality()
    {
        onJump = false;
        float currentClimbSpeed = Input.GetAxis("Horizontal");
        animator.SetFloat("speed", currentClimbSpeed);
        animator.SetBool("hang_move", Mathf.Abs(currentClimbSpeed) > 0.1);
        transform.position = climbController.currentClimbEdge.moveNearEdge(transform.position,
                currentClimbSpeed * horizontalClimbSpeed * Time.deltaTime);
        transform.position = climbController.currentClimbEdge.setOnBounds(transform.position) + new Vector3(0, -2f, 0);
        if (currentClimbSpeed > 0 && climbController.currentClimbEdge.playerOnRight
            && Input.GetKeyDown(KeyCode.Space))
        {
            onJump = true;
            if(climbController.currentClimbEdge.rightTarget != null)
            {
                transform.position = climbController.currentClimbEdge.rightTarget.minPoint;
                climbController.currentClimbEdge = climbController.currentClimbEdge.rightTarget;
                transform.rotation = climbController.currentClimbEdge.transform.rotation;
                transform.position = climbController.currentClimbEdge.setOnBounds(transform.position) + new Vector3(0, -2f, 0);
            }
        }
        if (currentClimbSpeed < 0 && climbController.currentClimbEdge.playerOnLeft
            && Input.GetKeyDown(KeyCode.Space))
        {
            onJump = true;
            if(climbController.currentClimbEdge.leftTarget != null)
            {
                transform.position = climbController.currentClimbEdge.leftTarget.maxPoint;
                climbController.currentClimbEdge = climbController.currentClimbEdge.leftTarget;
                transform.rotation = climbController.currentClimbEdge.transform.rotation;
                transform.position = climbController.currentClimbEdge.setOnBounds(transform.position) + new Vector3(0, -2f, 0);
            }
        }
    }
    public override void Exit()
    {
        animator.SetBool("climb", false);
    }

    public override string CheckTransitions()
    {
        if(Input.GetKeyDown("space") && !onJump && climbController.currentClimbEdge.isTop == true)
        {
            return "CLIMB_UP";
        }
        else if(Input.GetKeyDown("space") && !onJump && climbController.currentClimbEdge.isTop == false)
        {
            return "CLIMB_JUMP";
        }
        else if(Input.GetKeyDown(KeyCode.LeftControl))
        {
            return "CLIMB_FALL";
        }
        else
        {
            return myID;
        }
    }
}
