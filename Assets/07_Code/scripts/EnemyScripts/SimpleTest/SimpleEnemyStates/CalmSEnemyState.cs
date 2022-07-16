using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CalmSEnemyState : SimpleEnemyState
{
    private bool playerTriggered = false;

    public override void Enter()
    {
        playerTriggered = false;
        agent.SetDestination(controller.startPosition);
    }
    public override void Functionality()
    {
        animator.SetFloat("speed", agent.velocity.magnitude);
    }
    public override void Exit()
    {

    }
    public override string CheckTransitions()
    {
        if (playerTriggered) return "PLAYER_FOUND";
        else if (controller.getDamage) return "GET_DAMAGE";
        return myID;
    }

    public void PlayerTriggered()
    {
        playerTriggered = true;
    }
}
