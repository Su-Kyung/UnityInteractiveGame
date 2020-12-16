using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavAgent : MonoBehaviour
{
    public Transform destTr;    // 목표지점
    NavMeshAgent agent; // NavMeshAgent 컴포넌트

    // Start is called before the first frame update
    void Start()
    {
        // NavMeshAgent 컴포넌트 가져오기
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        // 생성된 경로가 유효한 경우
        if (agent.isPathStale == false)
        {
            agent.destination = destTr.position;
        }
    }
}
