using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAttack : MonoBehaviour
{
    // 공격 여부를 판단할 변수
    public bool attack = false;

    // AudioSource 컴포넌트를 저장할 변수
    //AudioSource _audio;
    // Animator 컴포넌트를 저장할 변수
    Animator animator;
    // 주인공 캐릭터의 Transform 컴포넌트
    Transform playerTr;
    // 적 캐릭터의 Transform 컴포넌트
    Transform enemyTr;
    // 총구 화염 효과
    //ParticleSystem muzzleFlash;

    // 다음 발사항 시간 계산용 변수
    float nextAttack = 0.0f;
    // 총알 발사 간격
    float attackRate = 1.0f;
    // 주인공을 향해 회전할 속도 계수
    float damping = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        // 컴포넌트 추출 및 변수 저장
        playerTr = GameObject.FindGameObjectWithTag("PLAYER").transform;
        enemyTr = GetComponent<Transform>();
        animator = GetComponent<Animator>();
        //_audio = GetComponent<AudioSource>();
        //muzzleFlash = firePos.GetComponentInChildren<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(this.transform.position, playerTr.position) <= 2.0f)
        {
            // 현재 시간이 다음 발사 시간보다 큰지를 확인
            if (Time.time >= nextAttack)
            {
                Attack();
                // 다음 발사 시간 계산
                nextAttack = Time.time + attackRate + Random.Range(0.0f, 0.5f);
            }
            else GameObject.Find("Player").GetComponent<PlayerDamage>().isDamaged = false;

            // 주인공이 있는 위치까지의 회전 각도 계산
            Quaternion rot = Quaternion.LookRotation(playerTr.position - enemyTr.position);
            // 보간함수를 사용해 점진적으로 회전시킴
            enemyTr.rotation = Quaternion.Slerp(enemyTr.rotation, rot, Time.deltaTime * damping);
        }
    }

    void Attack()
    {
        // Player 공격 (체력 감소)
        GameObject.Find("Player").GetComponent<PlayerDamage>().isDamaged = true;
        animator.SetTrigger("attack");
        
        //muzzleFlash.Play();
    }

}
