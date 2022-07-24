using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemyWeaponAttackState : SimpleEnemyState
{
    [SerializeField] GameObject weapon;
    [SerializeField] float delayBeforeAttack;
    [SerializeField] float delayAfterAttack;
    [SerializeField] float standartSpeed;
    private bool attackEnd = false;

    public override void Enter()
    {
        attackEnd = false;
        agent.speed = 0;
        StartCoroutine(Attack());
    }
    public override void Functionality()
    {

    }
    public override void Exit()
    {
        animator.SetBool("attackEnd", false);
        agent.speed = standartSpeed;
    }
    public override string CheckTransitions()
    {
        if (attackEnd) return "PLAYER_FOUND";
        else if (controller.getDamage) return "GET_DAMAGE";
        return myID;
    }

    private IEnumerator Attack()
    {
        animator.SetBool("startAttack", true);
        yield return new WaitForSeconds(delayBeforeAttack);
        weapon.SetActive(true);
        animator.SetBool("attacking", true);
        animator.SetBool("startAttack", false);
    }

    private IEnumerator EndAttack()
    {
        animator.SetBool("attacking", false);
        weapon.SetActive(false);
        yield return new WaitForSeconds(delayAfterAttack);
        animator.SetBool("attackEnd", true);
        attackEnd = true;
    }

    public void EndOfAttack()
    {
        StartCoroutine(EndAttack());
    }
}
