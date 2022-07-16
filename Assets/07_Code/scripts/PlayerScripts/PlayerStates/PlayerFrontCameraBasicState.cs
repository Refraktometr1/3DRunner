using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFrontCameraBasicState : PlayerWalkState
{
    [SerializeField] private GameObject frontCamera;
    [SerializeField] private GameObject freeCamera;

    public override void Enter()
    {
        frontCamera.SetActive(true);
        freeCamera.SetActive(false);
        base.Enter();
    }

    public override void Exit()
    {
        frontCamera.SetActive(false);
        freeCamera.SetActive(true);
        base.Exit();
    }

    public override string CheckTransitions()
    {
        if (!GroundCheck(0.5f))
        {
            return "FALL";
        }
        else if (Input.GetKeyDown("space"))
        {
            return "JUMP";
        }
        else
        {
            return "FRONT_WALK";
        }
    }

    protected override void MovePlayer()
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

    protected override Quaternion RotateToCamera(Vector3 currSpeed)
    {
        float targetAngle = Mathf.Atan2(currSpeed.x, currSpeed.z) * Mathf.Rad2Deg + Camera.main.transform.eulerAngles.y;
        return Quaternion.Euler(0, targetAngle, 0);
    }

    protected override bool onFront()
    {
        return true;
    }

}
