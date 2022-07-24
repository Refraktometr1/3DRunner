using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAimWalkState : PlayerState
{
    [SerializeField] private float upBackMoveSpeed;
    [SerializeField] private float rightLeftMoveSpeed;

    [SerializeField] private float gravityPower;

    [SerializeField] private GameObject aimCamera;
    [SerializeField] private GameObject freeCamera;

    [SerializeField] private Transform bulletStartObject;
    [SerializeField] private Image target;
    [SerializeField] private GameObject bullet;

    public override void Enter()
    {
        aimCamera.SetActive(true);
        freeCamera.SetActive(false);
        animator.SetBool("aiming", true);
    }
    public override void Functionality()
    {
        float currSpeedVertical = Input.GetAxis("Vertical");
        float currSpeedHorizontal = Input.GetAxis("Horizontal");
        transform.rotation = RotateToCamera();
        controller.Move(transform.forward * upBackMoveSpeed * currSpeedVertical * Time.deltaTime);
        controller.Move(transform.right * rightLeftMoveSpeed * currSpeedHorizontal * Time.deltaTime);
        animator.SetFloat("speed", Mathf.Abs(new Vector2(currSpeedVertical, currSpeedHorizontal).magnitude));
        if (Mathf.Abs(currSpeedVertical) >= Mathf.Abs(currSpeedHorizontal))
        {
            animator.SetFloat("speedY", currSpeedVertical < 0 ? -1 : 1);
            animator.SetFloat("speedX", 0);
        }
        else
        {
            animator.SetFloat("speedX", currSpeedHorizontal < 0 ? -1 : 1);
            animator.SetFloat("speedY", 0);
        }
        if (!GroundCheck(0.1f)) controller.Move(Vector3.down * gravityPower * Time.deltaTime);

        if(Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }
    public override void Exit()
    {
        aimCamera.SetActive(false);
        freeCamera.SetActive(true);
        animator.SetBool("aiming", false);
    }

    public override string CheckTransitions()
    {
        if (!GroundCheck(0.5f)) return "FALL";
        if (Input.GetMouseButton(1)) return "AIM_WALK";
        else return "WALK";
    }

    private Quaternion RotateToCamera()
    {
        float targetAngle = Camera.main.transform.eulerAngles.y;
        return Quaternion.Euler(0, targetAngle, 0);
    }

    private void Shoot()
    {
        SimpleBuletScript b = Instantiate(bullet, bulletStartObject.position, Quaternion.identity).GetComponent<SimpleBuletScript>();
        b.gameObject.tag = "Weapon";
        b.SetDirection(Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0.0f)).GetPoint(100f), false);
    }
}
