using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackState : PlayerState
{
    private float attackCount;
    private string nextState;

    [SerializeField] private GameObject weapon;
    [SerializeField] private GameObject weaponCollider;

    public override void Enter()
    {
        attackCount = 0;
        nextState = "ATTACK";
        weapon.SetActive(true);
        animator.SetBool("attacking", true);
    }
    public override void Functionality()
    {
        if (Input.GetMouseButtonDown(0)) attackCount++;
    }
    public override void Exit()
    {
        weapon.SetActive(false);
        animator.SetBool("attacking", false);
        weaponCollider.SetActive(false);
    }

    public override string CheckTransitions()
    {
        return nextState;
    }

    public void FirstAttackAnimationEnd()
    {
        if (attackCount < 1)
        {
            nextState = "WALK";
        }
    }

    public void SecondAttackAnimationEnd()
    {
        if (attackCount < 2)
        {
            nextState = "WALK";
        }
    }

    public void ThirdAttackAnimationEnd()
    {
        nextState = "WALK";
    }

    public void AttackColliderStart()
    {
        weaponCollider.SetActive(true);
    }
}
