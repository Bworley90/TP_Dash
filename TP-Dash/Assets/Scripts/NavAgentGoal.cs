using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavAgentGoal : MonoBehaviour
{
    private Transform goal;
    private NavMeshAgent agent;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        goal = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        agent.destination = goal.position;
    }
}
