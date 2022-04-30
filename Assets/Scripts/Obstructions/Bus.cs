using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bus : ObstructionPullMono
{
    private void Awake()
    {
        isStatic = false;
        isBonus = false;
    }
}
