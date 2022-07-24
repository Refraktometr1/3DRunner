using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class STTriggeredState : SimpleTurretState
{
    private bool playerStilHere = true;
    private Vector3 playerPosition;
    [SerializeField] Transform bulletStartObject;

    [SerializeField] private float delayBeforeShot;
    [SerializeField] private GameObject bulet;

    [SerializeField] float xAxisRotateSpeed;
    [SerializeField] float yAxisRotateSpeed;
    [SerializeField] private Transform yRotateElement;
    [SerializeField] private Transform xRotateElement;

    [SerializeField] private bool parabol;

    private Animator animator;

    public override void Enter()
    {
        if (animator == null) animator = GetComponent<Animator>();
        playerStilHere = true;
        playerPosition = Vector3.zero;
        StartCoroutine(Attack());
    }
    public override void Functionality()
    {
        if (yRotateElement != null)
        {
            Vector3 targerRotation = (playerPosition - yRotateElement.position).normalized;
            yRotateElement.forward = new Vector3(targerRotation.x, 0, targerRotation.z);
        }

        if(xRotateElement != null)
        {
            xRotateElement.forward = (playerPosition - xRotateElement.position).normalized;
        }
    }
    public override void Exit()
    {

    }
    public override string CheckTransitions()
    {
        if (!playerStilHere) { return "CALM"; }
        else if (controller.getDamage) { return "GET_DAMAGE"; }
        return myID;
    }

    public void PlayerStillHere(Vector3 pos)
    {
        playerPosition = pos;
    }

    public void PlayerGoAway()
    {
        playerStilHere = false;
        StopAllCoroutines();
    }

    private IEnumerator Attack()
    {
        yield return new WaitForSeconds(delayBeforeShot);
        animator.SetBool("isShoot", true);
        SimpleBuletScript b = Instantiate(bulet, bulletStartObject.position, Quaternion.identity).GetComponent<SimpleBuletScript>();
        b.SetDirection(playerPosition + Vector3.up, parabol);
        yield return StartCoroutine(Attack());
    }
}
