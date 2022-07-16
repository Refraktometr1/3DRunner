using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalkState : PlayerState
{
    [SerializeField] protected float moveSpeed;
    [SerializeField] private float gravityPower;

    public override void Enter()
    {
        mainController.onFrontState = onFront();
        PlayerFallState.jumpCount = 0;
        float targetAngle = Camera.main.transform.eulerAngles.y;
        transform.rotation = Quaternion.Euler(0, targetAngle, 0);
        controller.enabled = true;
    }
    public override void Functionality()
    {
        controller.enabled = true;
        MovePlayer();
        if (!GroundCheck(0.1f)) controller.Move(Vector3.down * gravityPower * Time.deltaTime);
    }
    public override void Exit()
    {

    }

    public override string CheckTransitions()
    {
        if (!GroundCheck(0.5f))
        {
            return "FALL";
        }
        else if (Input.GetMouseButtonDown(0))
        {
            return "ATTACK";
        }
        else if(Input.GetKeyDown("space"))
        {
            return "JUMP";
        }
        else if(Input.GetMouseButtonDown(1))
        {
            return "AIM_WALK";
        }
        else
        {
            return myID;
        }
    }

    protected virtual void MovePlayer()
    {
        Vector3 currSpeed = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;
        if (currSpeed.magnitude > 0.1f)
        {
            Quaternion r = RotateToCamera(currSpeed);
            transform.rotation = r;
            Vector3 currDirection = r * Vector3.forward;
            controller.Move(currDirection * moveSpeed * Time.deltaTime);
        }
        animator.SetFloat("speed", Mathf.Abs(currSpeed.magnitude));
    }

    protected virtual Quaternion RotateToCamera(Vector3 currSpeed)
    {
        float targetAngle = Mathf.Atan2(currSpeed.x, currSpeed.z) * Mathf.Rad2Deg + Camera.main.transform.eulerAngles.y;
        return Quaternion.Euler(0, targetAngle, 0);
    }

    protected virtual bool onFront()
    {
        return false;
    }
}
