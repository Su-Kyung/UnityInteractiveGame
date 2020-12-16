using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // 좀비가 출현할 위치를 담을 배열
    public Transform[] points;
    // 좀비 프리팹을 저장할 변수
    public GameObject zombie;
    // 좀비를 생성할 주기
    public float createTime = 3.0f;
    // 좀비의 최대 생성 개수
    public int maxZombie = 1;
    // 게임 종료 여부를 판단할 변수
    public bool isGameOver = false;

    // Kill Count 표시
    public Text killText;
    // 좀비를 죽인 횟수
    int killCount = 0;

    // 재시작 버튼
    public GameObject restartBtn;

    // Start is called before the first frame update
    void Start()
    {
        // 하이러키 뷰의 SpawnPointGroup을 찾아 하위에 있는 모든 Transform 컴포넌트를 찾아옴
        points = GameObject.Find("SpawnPointGroup").GetComponentsInChildren<Transform>();
        if (points.Length > 0)
        {
            StartCoroutine(this.CreateZombie());
        }
    }

    // 좀비를 생성하는 코루틴 함수
    IEnumerator CreateZombie()
    {
        // 게임 종료 시까지 무한 루프
        while (!isGameOver)
        {
            // 현재 생성된 좀비의 개수 산출
            int zombieCount = (int)GameObject.FindGameObjectsWithTag("ZOMBIE").Length;
            // 좀비의 최대 생성 개수보다 작을 때만 좀비를 생성
            if (zombieCount < maxZombie)
            {
                // 좀비의 생성 주기 시간만큼 대기
                yield return new WaitForSeconds(createTime);
                // 불규칙적인 위치 산출
                int idx = Random.Range(1, points.Length);
                // 좀비의 동적 생성
                Instantiate(zombie, points[idx].position, points[idx].rotation);
            }
            else
            {
                yield return null;
            }
        }

        // 재시작 버튼 활성화
        restartBtn.SetActive(true);
    }

    public void Restart()
    {
        // 씬을 다시 로드
        SceneManager.LoadScene("GameScene");
        // 재시작 버튼 비활성화
        restartBtn.SetActive(false);
        isGameOver = false;
    }

    public void AddKillCount()
    {
        ++killCount;    // 횟수 증가
        killText.text = "Kill Count" + killCount;
    }
}
