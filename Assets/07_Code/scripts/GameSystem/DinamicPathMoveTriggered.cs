using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinamicPathMoveTriggered : DinamicPathMove
{
    public bool isMoving;

    void Update()
    {
        if (isMoving)
        {
            delta = MoveToTarget();
        }
    }
}
