using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyTrace : MonoBehaviour
{
    public Transform playerTr;
    NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        Move(playerTr.position);
    }
    void Move(Vector3 pos)
    {
        if (agent.isPathStale == false)
        {
            agent.destination = pos;
            agent.isStopped = false;
        }
    }
}