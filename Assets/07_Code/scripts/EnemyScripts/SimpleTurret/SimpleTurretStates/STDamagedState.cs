using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class STDamagedState : SimpleTurretState
{
    public override void Enter()
    {
        Destroy(gameObject);
    }
    public override void Functionality()
    {

    }
    public override void Exit()
    {

    }
    public override string CheckTransitions() { return myID; }
}
