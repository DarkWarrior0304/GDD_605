﻿using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public NavMeshAgent agent;

    public Transform player;

    EnemyFOV fov;

    public LayerMask whatIsGround, Player;

    //Patroling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //States
    bool isAggro = false;

    private void Awake()
    {
        player = GameObject.Find("player").transform;
        fov = GetComponent<EnemyFOV>();
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        
        if (isAggro)
        {
            ChasePlayer();
        }
    }

    public void Patroling()
    {
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
            agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;
        agent.speed = 6;

        //Walkpoint reached
        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
    }
    public void SearchWalkPoint()
    {
        //Calculate random point in range
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;
    }

    public void ChasePlayer()
    {
        agent.SetDestination(player.position);
        agent.speed = 12;
    }

    public void OnDamageTaken()
    {
        isAggro = true;
    }

}
