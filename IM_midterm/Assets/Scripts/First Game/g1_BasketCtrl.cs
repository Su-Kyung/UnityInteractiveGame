using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO: basket에 사과 넣으면 10점 더하도록
public class g1_BasketCtrl : MonoBehaviour
{
    public g1_ScoreMng sm;     //g1_ScoreMng와 연결

    private void OnCollisionEnter(Collision other)
    {
        // 더하는 점수를 10으로 설정
        sm.AddScore(10);
    }
}
