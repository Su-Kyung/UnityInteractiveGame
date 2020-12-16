using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyPatrol : MonoBehaviour
{
    public Transform[] wayPotins;

    int nextIndex = 0;
    NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (agent.remainingDistance < 1.0f && agent.velocity.magnitude < 0.5f) //목표지점도달했는지 확실히 알수 있음
        {
            nextIndex = Random.Range(0, wayPotins.Length);
            Move(wayPotins[nextIndex].position);
        }
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