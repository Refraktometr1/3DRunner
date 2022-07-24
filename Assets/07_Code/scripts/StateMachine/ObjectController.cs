using System;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController : MonoBehaviour
{
    [NonSerialized] public StateMachine machine;
    [NonSerialized] public Dictionary<string, State> states;
    [NonSerialized] public string currentStateIndex;
    [NonSerialized] public string firstStateName;

    private void Start()
    {
        machine = new StateMachine();
        createStateDictionary();
        foreach (KeyValuePair<string, State> entry in states)
        {
            entry.Value.myID = entry.Key;
        }
        machine.Initialize(states[firstStateName]);
        currentStateIndex = machine.currentState.myID;
    }

    protected virtual void createStateDictionary() {}

    void Update()
    {
        machine.currentState.Functionality();
        string newIndex = machine.currentState.CheckTransitions();
        if (newIndex != currentStateIndex)
        {
            machine.ChangeState(states[newIndex]);
            currentStateIndex = newIndex;
        }
        currentStateIndex = machine.currentState.myID;
    }
}
