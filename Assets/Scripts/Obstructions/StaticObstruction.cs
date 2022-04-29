using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticObstruction : ObstructionPullMono
{
    private void Awake()
    {
        isBonus = false;
        isStatic = true;
    }
}
