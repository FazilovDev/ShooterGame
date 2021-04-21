using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CrabAI : MonoBehaviour
{
    private NavMeshAgent agent;
    public float Speed;

    public GameObject TargetPlayer;

    private void Start()
    {
        agent = GetComponentInParent<NavMeshAgent>();
        agent.speed = Speed;
    }

    private void Update()
    {
        agent.SetDestination(TargetPlayer.transform.position);
    }


}
