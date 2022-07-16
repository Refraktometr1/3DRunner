using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : MonoBehaviour
{
    public enum PlayerState {WALK, JUMP, FALL, CLIMB, ATTACK, AIM_WALK}
    public PlayerState currentState;

    private void OnEnable()
    {
        currentState = PlayerState.WALK;
    }
}
