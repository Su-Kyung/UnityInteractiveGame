using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class w11_EnemyAI5 : MonoBehaviour
{
    // 적 캐릭터의 상태를 표현하기 위한 열거형 변수 정의
    public enum State
    {
        PATROL,
        TRACE,
        ATTACK,
        DIE
    }

    // 상태를 저장할 변수
    public State state = State.PATROL;
    // 공격 사정거리
    public float attackDist = 5.0f;
    // 추척 사정거리
    public float traceDist = 10.0f;
    // 사망 여부를 판단할 변수
    public bool isDie = false;
    // 주인공의 위치를 저장할 변수
    Transform playerTr;
    // 적 캐릭터의 위치를 저장할 변수
    Transform enemyTr;
    // 코루틴에서 사용할 지연시간 변수
    WaitForSeconds ws;
    // 이동을 제어하는 MoveAgent 클래스를 저장할 변수
    //w11_MoveAgent3 moveAgent;
    w11_MoveAgent4 moveAgent;
    // Animator 컴포넌트를 저장할 변수
    Animator animator;
    // 총 발사를 제어하는 EnemyFire 클래스를 저장할 변수
    w11_EnemyFire enemyFire;

    void Awake()    // 오브젝트가 비활성화된 상태에서도 돌아감
    {
        // 주인공 게임오브젝트 추철
        GameObject player = GameObject.FindGameObjectWithTag("PLAYER");
        // 주인공의 Transform 컴포넌트 추출
        if (player != null)
        {
            playerTr = player.transform;
        }
        // 적 캐릭터의 Transform 컴포넌트 추출
        enemyTr = GetComponent<Transform>();
        // 이동을 제어하는 MoveAgent 클래스를 추출
        //moveAgent = GetComponent<w11_MoveAgent3>();
        moveAgent = GetComponent<w11_MoveAgent4>();
        // Animator 컴포넌트 추출
        animator = GetComponent<Animator>();
        // 총 발사를 제어하는 EnemyFire 클래스를 추출
        enemyFire = GetComponent<w11_EnemyFire>();
        // 코루틴의 지연시간 생성
        ws = new WaitForSeconds(0.3f);
    }

    void OnEnable()
    {
        //CheckState 코루틴 함수 실행
        StartCoroutine(CheckState());
        // Action 코루틴 함수 실행
        StartCoroutine(Action());
    }

    // 적 캐릭터의 상태를 검사하는 코루틴 함수
    IEnumerator CheckState()
    {
        // 적 캐릭터가 사망하기 전까지 도는 무한루프
        while (!isDie)
        {
            // 상태가 사망이면 코루틴 함수를 종료시킴
            if (state == State.DIE) yield break;
            // 주인공과 적 캐릭터 간의 거리르 계산
            float dist = Vector3.Distance(playerTr.position, enemyTr.position);
            if (dist <= attackDist) // 공격 사정거리 이내의 경우
                state = State.ATTACK;
            else if (dist <= traceDist) // 추적 사정거리 이내의 경우
                state = State.TRACE;
            else
                state = State.PATROL;
            // 0.3초 동안 대기하는 동안 제어권을 양보
            yield return ws;
        }
    }

    // 상태에 따라 적 캐릭터의 행동을 처리하는 코루틴 함수
    IEnumerator Action()
    {
        while (!isDie)
        {
            yield return ws;

            switch (state)  // 상태에 따라 분기 처리
            {
                case State.PATROL:
                    enemyFire.isFire = false;   // 총 발사 정지
                    // 순찰 모드를 활성화
                    moveAgent.SetPatrolling(true);
                    animator.SetBool("IsMove", true);
                    break;

                case State.TRACE:
                    enemyFire.isFire = false;   // 총 발사 정지
                    // 주인공의 위치를 넘겨 추적 모드로 변경
                    moveAgent.SetTraceTarget(playerTr.position);
                    animator.SetBool("IsMove", true);
                    break;

                case State.ATTACK:
                    moveAgent.Stop();   // 순찰 및 추적을 정지
                    animator.SetBool("IsMove", false);
                    if (enemyFire.isFire == false)
                        enemyFire.isFire = true;    // 총알 발사 시작
                    break;

                case State.DIE:
                    isDie = true;
                    enemyFire.isFire = false;
                    moveAgent.Stop();   // 순찰 및 추적을 정지
                    animator.SetTrigger("Die"); // 사망 애니메이션 실행
                    GetComponent<CapsuleCollider>().enabled = false;
                    break;
            }
        }
    }

    void Update()
    {
        // Speed 파라미터에 이동 속도를 전달
        animator.SetFloat("Speed", moveAgent.GetSpeed());
    }
}
