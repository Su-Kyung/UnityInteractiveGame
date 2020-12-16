using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class w12_Damage : MonoBehaviour
{
    public float currHp = 100;

    // 충돌한 Collider의 IsTrigger 옵션이 체크됐을 때 발생
    void OnTriggerEnter(Collider coll)
    {
        // 충돌한 Collider의 태그가 BULLET이면 Player의 currHP를 차감
        if (coll.tag == "BULLET")
        {
            Destroy(coll.gameObject);
            currHp -= 5.0f;
            Debug.Log("Player HP = " + currHp.ToString());
            // Player의 생명이 0이하이면 사망 처리
            if (currHp <= 0.0f)
            {
                PlayerDie();
            }
        }
    }
    
    // Player의 사망 처리 루틴
    void PlayerDie()
    {
        Debug.Log("PlayerDie!!");
    }
}
