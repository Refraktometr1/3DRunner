using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class MoneyObstruction : ObstructionPullMono
{
    private void Awake()
    {
        isBonus = true;
    }
}
