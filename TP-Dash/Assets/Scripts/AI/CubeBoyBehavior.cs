﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CubeBoyBehavior : MonoBehaviour
{
    public enum State
    {
        patrol,
        chasing,
        returning
    }

    public State currentState;
    private Vector3 goalPosition;
    public Transform[] waypoints;
    private int index;
    private NavMeshAgent agent;
    private Transform player;

    [Header("Patrolling Settings")]
    [Range(1, 100)]
    [Tooltip("Speed when not chasing character")]
    public float patrollingSpeed;
    [Tooltip("Is the character patrolling")]

    [Header("Chase Settings")]
    [Range(0, 200)]
    public int spottedDistance;
    [Range(20, 300)]
    public int chaseDistance;
    [Range(0, 200)]
    public int chaseSpeed;

    //Distances
    private float distanceToPlayer;
    private float distanceFromWaypoint;

    // Animations
    private Animator anim;





    private void Start()
    {
        index = 0;
        currentState = State.patrol;
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        CalculatedDistances();
        StateChange();
        Patrolling();
        ChasePlayer();
        UpdateAnimations();
    }

    private void Patrolling()
    {
        if(currentState == State.patrol)
        {
            agent.speed = patrollingSpeed;
            goalPosition = waypoints[index].position;
            agent.destination = goalPosition;
            if (distanceFromWaypoint < 1) // If agent gets to point
            {
                if (index == waypoints.Length - 1)
                {
                    index = 0;
                }
                else
                {
                    index++;
                }
            }
        }
        
    }

    private void ChasePlayer()
    {
        if(currentState == State.chasing)
        {
            agent.destination = player.position;
            agent.speed = chaseSpeed;
            //CheckOnTriggerEnter for actions when caught
        }
    }


    private void CalculatedDistances()
    {
       distanceFromWaypoint = Vector3.Distance(transform.position, waypoints[index].position);
        distanceToPlayer = Vector3.Distance(transform.position, player.position);
    }


    private void StateChange()
    {
        if(currentState == State.patrol)
        {
            if(distanceToPlayer < spottedDistance)
            {
                currentState = State.chasing;
            }
        }
        if(currentState == State.chasing)
        {
            if(distanceFromWaypoint > chaseDistance)
            {
                currentState = State.returning;
            }
        }
        if(currentState == State.returning)
        {
            agent.destination = waypoints[index].position;
            if(distanceFromWaypoint < 1 )
            {
                currentState = State.patrol;
            }
        }
    }

    private void UpdateAnimations()
    {
        anim.SetFloat("Speed", agent.speed);
    }

  


}
