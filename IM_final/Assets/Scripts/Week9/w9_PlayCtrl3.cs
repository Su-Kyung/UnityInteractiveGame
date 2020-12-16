using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class w9_PlayCtrl3 : MonoBehaviour
{
    // 이동 속도 변수
    public float moveSpeed = 10.0f;
    // 회전 속도 변수
    public float rotSpeed = 80.0f;
    // Animation 컴포넌트를 저장하기 위한 변수
    Animation anim;

    // Start is called before the first frame update
    void Start()
    {
        // Animation 컴포넌트를 변수에 할당
        anim = GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        float r = Input.GetAxis("Mouse X");

        // 전후좌우 이동 방향 벡터 계산
        Vector3 moveDir = (Vector3.forward * v) + (Vector3.right * h);
        // Translate(이동 방향 * 속도 * 변위값 * Time.deltaTime, 기준좌표)
        transform.Translate(moveDir.normalized * moveSpeed * Time.deltaTime, Space.Self);
        // Vector3.up 축을 기준으로 rotSpeed 만큼의 속도로 회전
        transform.Rotate(Vector3.up * rotSpeed * Time.deltaTime * r);

        // 키보드 입력값을 기준으로 동작하 애니메이션 수행
        if (v >= 0.1f)
        {
            anim.CrossFade("RunF", 0.3f);   // 전진 애니메이션
        }
        else if (v <= -0.1f)
        {
            anim.CrossFade("RunB", 0.3f);   // 후진 애니메이션
        }
        else if (h >= 0.1f)
        {
            anim.CrossFade("RunR", 0.3f);   // 우측 이동 애니메이션
        }
        else if (h <= -0.1f)
        {
            anim.CrossFade("RunL", 0.3f);   // 좌측 이동 애니메이션
        }
        else
        {
            anim.CrossFade("Idle", 0.3f);   // 정지시 Idle애니메이션
        }
    }
}
