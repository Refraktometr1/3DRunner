using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggeredSEnemyState : SimpleEnemyState
{
    private bool playerStillHere = true;
    private bool playerOnAttackDistance = false;
    private Vector3 playerPosition = Vector3.zero;
    public override void Enter()
    {
        playerOnAttackDistance = false;
    }
    public override void Functionality()
    {
        agent.SetDestination(playerPosition);
        animator.SetFloat("speed", agent.velocity.magnitude);
    }
    public override void Exit()
    {

    }
    public override string CheckTransitions()
    {
        if (!playerStillHere) return "CALM";
        else if (playerOnAttackDistance) return "PLAYER_ATTACKED";
        else if (controller.getDamage) return "GET_DAMAGE";
        return myID;
    }

    public void PlayerStillHere(Vector3 playerPos)
    {
        playerPosition = playerPos;
        playerStillHere = true;
    }

    public void PlayerRunAway()
    {
        playerStillHere = false;
    }

    public void PlayerOnAttackDistance()
    {
        playerOnAttackDistance = true;
    }
}
