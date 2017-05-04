using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Enemy : Character
{
    [Header("Enemy")]
    public Transform target;


    protected NavMeshAgent agent;
    
    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    protected void SeekToTarget()
    {
        if(target != null)
        {
            agent.SetDestination(target.position);
        }
        
    }

    protected bool IsAtTarget()
    {
        if (!agent.hasPath)
            return false;
        return agent.remainingDistance <= agent.stoppingDistance;
    }
}
