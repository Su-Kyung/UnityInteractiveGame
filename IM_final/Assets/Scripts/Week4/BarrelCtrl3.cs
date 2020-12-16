using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelCtrl3 : MonoBehaviour
{
    public GameObject expEffect;    // 폭발 효과 프리팹
    public AudioClip expSound;  // 폭발 사운드 클립
    int hitCount = 0;   // 대포에 맞은 횟수
    Rigidbody rb;   // Rigidbody 컴포넌트
    AudioSource ads;    // AudioSource 컴포넌트

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Rigidbody 컴포넌트 가져오기
        ads = GetComponent<AudioSource>();  // AudioSource 컴포넌트 가져오기
    }

    void OnCollisionEnter(Collision coll)
    {
        if (coll.collider.CompareTag("BULLET")) // 충돌한 게임오브젝트의 태그 비교
        {
            if (++hitCount == 3) // 총에 맞은 횟수 증가, 3발 맞았는지 확인
            {
                ExpBarrel(coll);    // 폭발 처리 함수
            }
        }
    }

    void ExpBarrel(Collision coll)
    {
        rb.AddForce(0, 10000, 0);   // 위쪽으로 힘을 가함

        GameObject effect = Instantiate(expEffect); // 폭발 효과 생성
        effect.transform.position = coll.transform.position;    // 폭발 위치 지정
        Destroy(effect, 2); // 2초 후 폭발 효과 제거

        // 오브젝트를 회색으로 변경
        GetComponent<Renderer>().material.color = Color.gray;

        ads.PlayOneShot(expSound);  // 폭발음 재생
    }
}
