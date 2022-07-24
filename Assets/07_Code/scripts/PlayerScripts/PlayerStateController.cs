using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateController : ObjectController
{
    public bool onFrontState;

    public void GetDamaged()
    {
        currentStateIndex = "GET_DAMAGE";
        machine.ChangeState(states["GET_DAMAGE"]);
    }

    public void ForceJump()
    {
        currentStateIndex = "JUMP";
        machine.ChangeState(states["JUMP"]);
    }

    protected override void createStateDictionary()
    {
        firstStateName = "WALK";
        states = new Dictionary<string, State>();
        states.Add("WALK", GetComponent<PlayerWalkState>());
        states.Add("JUMP", GetComponent<PlayerJumpState>());
        states.Add("SECOND_JUMP", GetComponent<PlayerSecondJumpState>());
        states.Add("FALL", GetComponent<PlayerFallState>());
        states.Add("ATTACK", GetComponent<PlayerAttackState>());
        states.Add("CLIMB", GetComponent<PlayerClimbState>());
        states.Add("CLIMB_UP", GetComponent<PlayerClimbUpState>());
        states.Add("CLIMB_FALL", GetComponent<FallClimbState>());
        states.Add("CLIMB_JUMP", GetComponent<ClimbJumpUpState>());
        states.Add("AIM_WALK", GetComponent<PlayerAimWalkState>());
        states.Add("GET_DAMAGE", GetComponent<GetDamageState>());
        states.Add("FRONT_WALK", GetComponent<PlayerFrontCameraBasicState>());
    }

    public void moveToPosition(Vector3 position)
    {
        GetComponent<CharacterController>().enabled = false;
        transform.position = position;
        GetComponent<CharacterController>().enabled = true;
        machine.ChangeState(states["FRONT_WALK"]);
    }
}
