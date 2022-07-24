using UnityEngine;

namespace Code.scripts.npc
{
    public class GoingState: NpcState
    {
        [SerializeField] private GameObject[] target;
        public override void Enter()
        {
            
        }

        public override void Functionality()
        {
            
        }

        public override void Exit()
        {
        }

        public override string CheckTransitions()
        {
            return "";
        }
    }
}