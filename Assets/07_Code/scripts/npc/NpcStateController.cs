using System;
using System.Collections.Generic;

namespace Code.scripts.npc
{
    public class NpcStateController: ObjectController
    {
        protected override void createStateDictionary()
        {
            firstStateName = "Going";
            states = new Dictionary<string, State>();
            states.Add("Going", GetComponent<GoingState>());
        }

        void Update()
        {
            machine.currentState.Functionality();
            string newIndex = machine.currentState.CheckTransitions();
            if(newIndex != currentStateIndex)
            {
                machine.ChangeState(states[newIndex]);
                currentStateIndex = newIndex;
            }
        }
    }
}