using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemyJumpAttackState : SimpleEnemyState
{
    [SerializeField] GameObject attackPoint;
    [SerializeField] float delayBeforeAttack;
    [SerializeField] float delayAfterAttack;
    [SerializeField] float standartSpeed;
    [SerializeField] float speedOfAttack;
    private bool attackEnd = false;
    private bool inAir;
    private Vector3 currentTarget;
    private float startLanding = 1.0f;

    public override void Enter()
    {
        attackEnd = false;
        inAir = false;
        agent.speed = 0;
        animator.SetBool("attackEnd", false);
        animator.SetBool("grounded", false);
        animator.SetBool("readyToAttack", true);
        StartCoroutine(Attack());
    }
    public override void Functionality()
    {
        agent.SetDestination(transform.position);
        if(inAir)
        {
            transform.position = Vector3.MoveTowards(transform.position, currentTarget, speedOfAttack * Time.deltaTime);
            if ((transform.position - currentTarget).magnitude <= startLanding)
            {
                animator.SetBool("grounded", true);
                animator.SetBool("attacking", false);
            }
        }
    }
    public override void Exit()
    {
        attackPoint.SetActive(false);
        animator.SetBool("readyToAttack", false);
    }
    public override string CheckTransitions()
    {
        if (attackEnd) return "PLAYER_FOUND";
        else if (controller.getDamage) return "GET_DAMAGE";
        return myID;
    }

    private IEnumerator Attack()
    {
        attackPoint.SetActive(true);
        yield return new WaitForSeconds(delayBeforeAttack);
        attackPoint.SetActive(false);
        animator.SetBool("attacking", true);
        inAir = true;
        currentTarget = attackPoint.transform.position;
    }

    private IEnumerator EndAttack()
    {
        yield return new WaitForSeconds(delayAfterAttack);
        animator.SetBool("attackEnd", true);
        agent.speed = standartSpeed;
        attackEnd = true;
    }

    public void EndOfAttack()
    {
        inAir = false;
        StartCoroutine(EndAttack());
    }
}
