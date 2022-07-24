using UnityEngine;
using UnityEngine.AI;

namespace Code.scripts.npc
{
    public class NpcState: State
    {
        protected NavMeshAgent agent;
        protected PlayerStateController controller;
        protected Animator animator;

        void Awake()
        {
            agent = GetComponent<NavMeshAgent>();
            controller = GetComponent<PlayerStateController>();
            animator = GetComponent<Animator>();
        }
    }
}