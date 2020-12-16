using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAI : MonoBehaviour
{
    // 좀비 캐릭터의 상태를 표현하기 위한 열거형 변수 정의
    public enum State
    {
        PATROL, //순찰 모드
        TRACE,  //추적모드
        ATTACK, //공격모드
        DAMAGE, //피해모드
        DIE     //사망모드
    }

    // 상태를 저장할 변수
    public State state = State.PATROL;
    // 공격 사정거리
    public float attackDist = 1.0f;
    // 추적 사정거리
    public float traceDist = 4.0f;
    // 사망 여부를 판단할 변수
    public bool isDie = false;
    // 주인공의 위치를 저장할 변수
    Transform playerTr;
    // 좀비의 위치를 저장할 변수
    Transform zombieTr;
    // 코루틴에서 사용할 지연시간 변수
    WaitForSeconds ws;
    // 이동을 제어하는 MoveZombie 클래스를 저장할 변수
    MoveZombie moveZombie;
    // Animator 컴포넌트를 저장할 변수
    Animator animator;

    // 총 발사를 제어하는 EnemyFire 클래스를 저장할 변수
    //w11_EnemyFire enemyFire;
    // 공격을 제어하는 ZombieAttack 클래스를 저장할 변수
    ZombieAttack zombieAttack;

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
        zombieTr = GetComponent<Transform>();
        // 이동을 제어하는 MoveAgent 클래스를 추출
        //moveAgent = GetComponent<w11_MoveAgent3>();
        moveZombie = GetComponent<MoveZombie>();
        // Animator 컴포넌트 추출
        animator = GetComponent<Animator>();
        
        // 좀비 공격을 제어하는 ZombieAttack 클래스를 호출
        zombieAttack = GetComponent<ZombieAttack>();

        // Cycle Offset 값을 불규칙하게 변경
        animator.SetFloat("offset", Random.Range(0.0f, 1.0f));
        // Speed 값을 불규칙하게 변경
        animator.SetFloat("walkSpeed", Random.Range(1.0f, 1.2f));

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
            float dist = Vector3.Distance(playerTr.position, zombieTr.position);
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
                // 순찰 : 정해진 포인트 순찰
                case State.PATROL:
                    zombieAttack.attack = false;    // 좀비 공격 정지
                    // 순찰 모드를 활성화
                    moveZombie.SetPatrolling(true);
                    break;
                // 추적 : 플레이어 추적
                case State.TRACE:
                    zombieAttack.attack = false;    // 좀비 공격 정지
                    // 주인공의 위치를 넘겨 추적 모드로 변경
                    moveZombie.SetTraceTarget(playerTr.position);
                    break;
                // 공격 : 플레이어 공격
                case State.ATTACK:
                    if (zombieAttack.attack == false)
                        zombieAttack.attack = true; // 좀비 공격 시작
                    break;
                // 피해 : 피해입었을 때
                case State.DAMAGE:
                    zombieAttack.attack = false;    // 좀비 공격 정지
                    moveZombie.Stop();  // 순찰 및 추적을 정지
                    animator.SetTrigger("damage");  // 피해 애니메이션 실행
                    break;
                // 죽음 : 죽었을 때
                case State.DIE:
                    isDie = true;
                    zombieAttack.attack = false;    // 좀비 공격 정지
                    moveZombie.Stop();   // 순찰 및 추적을 정지
                    animator.SetTrigger("death"); // 사망 애니메이션 실행
                    GetComponent<CapsuleCollider>().enabled = false;
                    break;
            }
        }
    }

    void Update()
    {
        // Speed 파라미터에 이동 속도를 전달
        animator.SetFloat("speed", moveZombie.GetSpeed());
    }

    public void OnPlayerDie()
    {
        if (isDie == false) //적캐릭터가 안죽었으면
        {
            moveZombie.Stop();
            //enemyFire.isFire = false;
            zombieAttack.attack = false;
            // 모드 코루틴 함수를 종료시킴
            StopAllCoroutines();
            animator.SetTrigger("PlayerDie");
        }
    }
}