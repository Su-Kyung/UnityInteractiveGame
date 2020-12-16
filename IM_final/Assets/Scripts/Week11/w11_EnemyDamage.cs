using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class w11_EnemyDamage : MonoBehaviour
{
    // 생명 게이지
    float hp = 100.0f;
    // 피격 시 사용할 혈흔 효과
    GameObject bloodEffect;

    // Start is called before the first frame update
    void Start()
    {
        // 혈흔 효과 프리팹을 로드
        bloodEffect = Resources.Load<GameObject>("BulletImpactFleshBigEffect");
    }

    void OnCollisionEnter(Collision coll)
    {
        if (coll.collider.tag == "BULLET")
        {
            Destroy(coll.gameObject);
            //hp -= coll.gameObject.GetComponent<BulletCtrl>().damage;

            w9_BulletCtrl bc = coll.gameObject.GetComponent<w9_BulletCtrl>();
            if (bc != null) //스크립트를 얻어왔을 때만(플레이어 총알에 맞았을때)
            {
                hp -= bc.damage;
                ShowBloodEffect(coll);
            }

            if (hp <= 0)
            {
                //GetComponent<w11_EnemyAI5>().state = w11_EnemyAI5.State.DIE;
                //GetComponent<w11_EnemyAI6>().state = w11_EnemyAI6.State.DIE;
                GetComponent<w12_EnemyAI7>().state = w12_EnemyAI7.State.DIE;
            }
        }
    }

    // 혈흔 효과를 생성하는 함수
    void ShowBloodEffect(Collision coll)
    {
        // 총알이 충돌한 지점 산출
        Vector3 pos = coll.contacts[0].point;
        // 총알이 충돌했을 때의 법선 벡터
        Vector3 _normal = coll.contacts[0].normal;
        // 총알의 충돌 시 방향 벡터의 회전값 계산
        Quaternion rot = Quaternion.FromToRotation(-Vector3.forward, _normal);
        // 혈흔 효과 생성
        GameObject blood = Instantiate<GameObject>(bloodEffect, pos, rot);
        Destroy(blood, 1.0f);
    }
}
