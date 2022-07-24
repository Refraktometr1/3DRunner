using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemyGetDamagedState : SimpleEnemyState
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
    public override string CheckTransitions()
    {
        return myID;
    }
}
