using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class SimpleEnemyStateController : ObjectController
{
    //public enum StateTypes {CALM, PLAYER_FOUND, PLAYER_ATTACKED, GET_DAMAGE }
    public bool getDamage = false;
    public Vector3 startPosition;

    [SerializeField] private bool jumpAttack = true;

    public void GetAttacked()
    {
        getDamage = true;
    }

    protected override void createStateDictionary()
    {
        startPosition = transform.position;
        firstStateName = "CALM";
        if (jumpAttack)
        {
            states = new Dictionary<string, State>();
            states.Add("CALM", GetComponent<CalmSEnemyState>());
            states.Add("PLAYER_FOUND", GetComponent<TriggeredSEnemyState>());
            states.Add("PLAYER_ATTACKED", GetComponent<SimpleEnemyJumpAttackState>());
            states.Add("GET_DAMAGE", GetComponent<SimpleEnemyGetDamagedState>());
        }
        else
        {
            states = new Dictionary<string, State>();
            states.Add("CALM", GetComponent<CalmSEnemyState>());
            states.Add("PLAYER_FOUND", GetComponent<TriggeredSEnemyState>());
            states.Add("PLAYER_ATTACKED", GetComponent<SimpleEnemyWeaponAttackState>());
            states.Add("GET_DAMAGE", GetComponent<SimpleEnemyGetDamagedState>());
        }
    }
}
