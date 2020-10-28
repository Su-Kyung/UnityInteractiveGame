using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

// TODO: 목표물 순찰 -> 과녁이 순찰 지점 중 랜덤으로 한 곳을 목적지로 설정하여 이동
public class g1_TargetPatrol : MonoBehaviour
{
    public Transform[] wayPotins;

    int nextIndex = 0;
    NavMeshAgent target;     //과녁

    // Start is called before the first frame update
    void Start()
    {
        target = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        // 과녁을 항상 조준할 수 있도록 방향 고정
        target.transform.eulerAngles = new Vector3(0.0f, 0.0f, 0.0f);

        // 과녁이 목적지에 도달했는지 검사
        if (target.remainingDistance < 1.0f && target.velocity.magnitude < 0.5f) //목표지점도달했는지 확실히 알수 있음
        {
            // 도달했다면 다음 목적지를 랜덤하게 지정
            nextIndex = Random.Range(0, wayPotins.Length);
            Move(wayPotins[nextIndex].position);
        }
    }

    // 목적지까지 이동
    void Move(Vector3 pos)
    {
        if (target.isPathStale == false)    // 현재 경로가 유효한가?
        {
            target.destination = pos;   // 다음 목적지를 pos로 지정
            target.isStopped = false;   // 이동 시작
        }
    }
}
