using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class STCalmState : SimpleTurretState
{
    private bool playerFound = false;

    public override void Enter()
    {
        playerFound = false;
    }
    public override void Functionality()
    {

    }
    public override void Exit()
    {

    }
    public override string CheckTransitions()
    {
        if (playerFound) { return "PLAYER_FOUND"; }
        else if (controller.getDamage) { return "GET_DAMAGE"; }
        return myID;
    }

    public void PlayerFound()
    {
        playerFound = true;
    }
}
