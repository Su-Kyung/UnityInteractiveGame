﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class w12_Damage2 : MonoBehaviour
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
        //Debug.Log("PlayerDie!!");

        // "ENEMY_" 태그로 지정된 모든 적 캐릭터를 추출해 배열에 저장
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("ENEMY_");
        // 배열의 처음부터 순회하면서 적 캐릭터의 OnPlayerDie 함수를 호출
        for (int i = 0; i < enemies.Length; i++)
        {
            enemies[i].SendMessage("OnPlayerDie", SendMessageOptions.DontRequireReceiver);
        }
    }
}