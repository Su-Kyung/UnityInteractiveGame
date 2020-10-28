using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// TODO: 점수 표시. 점수를 나타내는 Text UI에 점수를 반영하여 표시한다
public class g1_ScoreMng : MonoBehaviour
{
    public GameObject gameClear;    // 게임 클리어 UI
    public int endScore = 50;  // 종료 점수
    int score = 0;  // 현재 점수
    Text scoreText; // 점수 UI

    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<Text>();   // 텍스트 컴포넌트 가져오기
    }

    // 실제 점수 수치와 연동되는 함수
    public void AddScore(int add)
    {
        score += add;                       // 점수 추가
        scoreText.text = "점수 " + score;  // UI에 적용
        if (score >= endScore)              // 종료 점수이면
        {
            gameClear.SetActive(true);      // Game Clear 출력
        }
    }
}
