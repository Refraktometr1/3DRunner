using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplePathMoveTriggered : SimplePathMove
{
    public bool isMoving;

    void Update()
    {
        if(isMoving)
        {
            delta = MoveToTarget();
        }
    }
}
