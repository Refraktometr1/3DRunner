using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSecondJumpState : PlayerState
{
    [SerializeField] private float secondJumpPower;
    [SerializeField] private float gravityPower;
    [SerializeField] private float horizontalMoveSpeed;

    private float jumpVelocity;

    public override void Enter()
    {
        PlayerFallState.jumpCount++;
        jumpVelocity = secondJumpPower;
        animator.SetBool("jumping", true);
    }
    public override void Functionality()
    {
        MovePlayer();
        jumpVelocity -= gravityPower * Time.deltaTime;
        controller.Move(Vector3.up * jumpVelocity * Time.deltaTime);
    }
    public override void Exit()
    {

    }

    public override string CheckTransitions()
    {
        if (jumpVelocity <= 0)
        {
            return "FALL";
        }
        else
        {
            return "SECOND_JUMP";
        }
    }

    private void MovePlayer()
    {
        Vector3 currSpeed = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;
        if (currSpeed.magnitude > 0.1f)
        {
            float targetAngle = Mathf.Atan2(currSpeed.x, currSpeed.z) * Mathf.Rad2Deg + Camera.main.transform.eulerAngles.y;
            transform.rotation = Quaternion.Euler(0, targetAngle, 0);
            Vector3 currDirection = Quaternion.Euler(0, targetAngle, 0) * Vector3.forward;
            controller.Move(currDirection * horizontalMoveSpeed * Time.deltaTime);
        }
        animator.SetFloat("speed", Mathf.Abs(currSpeed.magnitude));
    }
}
