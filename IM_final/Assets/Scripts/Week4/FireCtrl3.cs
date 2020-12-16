using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCtrl3 : MonoBehaviour
{
    public GameObject bullet;   // 총알 프리팹
    public Transform firePos;   // 총알 발사좌표
    public AudioClip fireAC;    // 사격 음원

    ParticleSystem muzzleFlash; // 사격 이벤트
    AudioSource ads;    // 오디오 컴포넌트

    // Start is called before the first frame update
    void Start()
    {
        // 하위 오브젝트의 이펙트 컴포넌트 가져오기
        muzzleFlash = firePos.GetComponentInChildren<ParticleSystem>();
        // AudioSource 컴포넌트 가져오기
        ads = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // 마우스 좌측 버튼 클릭
        if (Input.GetMouseButtonDown(0))
        {
            Fire(); // 사격 처리 함수
        }
    }

    void Fire()
    {
        // 총알 프리팹 생성
        GameObject obj = Instantiate(bullet, firePos.position, firePos.rotation);
        Destroy(obj, 3);    // 3초 후 자동 소멸
        muzzleFlash.Play(); // 사격 이펙트 실행

        ads.PlayOneShot(fireAC);    // 사운드 재생
    }
}
