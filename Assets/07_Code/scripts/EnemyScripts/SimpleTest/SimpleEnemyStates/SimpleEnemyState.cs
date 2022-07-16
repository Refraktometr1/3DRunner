using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SimpleEnemyState : State
{
    protected NavMeshAgent agent;
    protected SimpleEnemyStateController controller;
    protected Animator animator;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        controller = GetComponent<SimpleEnemyStateController>();
        animator = GetComponent<Animator>();
    }
}
