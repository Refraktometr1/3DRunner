using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SimpleTurretStateController : ObjectController
{
    [NonSerialized] public bool getDamage = false;

    [SerializeField] private bool invincible;

    public void GetAttacked()
    {
        if(!invincible)
            getDamage = true;
    }

    protected override void createStateDictionary()
    {
        firstStateName = "CALM";
        states = new Dictionary<string, State>();
        states.Add("CALM", GetComponent<STCalmState>());
        states.Add("PLAYER_FOUND", GetComponent<STTriggeredState>());
        states.Add("GET_DAMAGE", GetComponent<STDamagedState>());
    }
}
