using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFallState : PlayerState
{
    [SerializeField] private float gravityPower;
    [SerializeField] private float horizontalMoveSpeed;

    private float jumpVelocity;

    public static int jumpCount = 0;

    public override void Enter()
    {
        if (!animator.GetBool("jumping")) animator.SetBool("jumping", true);
        jumpVelocity = 0;
    }
    public override void Functionality()
    {
        MovePlayer();
        jumpVelocity -= gravityPower * Time.deltaTime;
        controller.Move(Vector3.up * jumpVelocity * Time.deltaTime);
    }
    public override void Exit()
    {
        animator.SetBool("jumping", false);
    }

    public override string CheckTransitions()
    {
        if (GroundCheck(0.1f))
        {
            return mainController.onFrontState ? "FRONT_WALK" : "WALK";
        }
        else if(Input.GetKeyDown(KeyCode.Space) && jumpCount == 0)
        {
            return "JUMP";
        }
        else if(Input.GetKeyDown(KeyCode.Space) && jumpCount == 1)
        {
            return "SECOND_JUMP";
        }
        else
        {
            return "FALL";
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
