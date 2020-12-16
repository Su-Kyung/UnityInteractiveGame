using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreMng : MonoBehaviour
{
    public GameObject gameClear;    // 게임 클리어 UI
    public int endScore = 100;  // 종료 점수
    int score = 0;  // 현재 점수
    Text scoreText; // 점수 UI

    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<Text>();   // 텍스트 컴포넌트 가져오기
    }

    public void AddScore(int add)
    {
        score += add;                       // 점수 추가
        scoreText.text = "Score " + score;  // UI에 적용
        if (score >= endScore)              // 종료 점수이면
        {
            gameClear.SetActive(true);      // Game Clear 출력
        }
    }
}
