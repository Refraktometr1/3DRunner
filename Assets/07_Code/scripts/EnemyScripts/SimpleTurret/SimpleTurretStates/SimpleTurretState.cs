using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleTurretState : State
{
    protected SimpleTurretStateController controller;

    private void Awake()
    {
        controller = GetComponent<SimpleTurretStateController>();
    }
}
