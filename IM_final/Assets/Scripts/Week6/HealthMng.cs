using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthMng : MonoBehaviour
{
    public GameObject gameOver;    // 게임 종료 UI
    Image guage;                   // 체력 게이지

    // Start is called before the first frame update
    void Start()
    {
        guage = GetComponent<Image>();   // 이미지 컴포넌트 가져오기
    }

    public void SetHealth(float amount)
    {
        guage.fillAmount = amount;
        if (amount <= 0)              // 게이지가 0이면
        {
            gameOver.SetActive(true);      // Game Over 출력
        }
    }
}
