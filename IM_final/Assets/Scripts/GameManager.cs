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

    public Transform[] itemPoints;  // 생성지점 위치 리스트
    public GameObject item; // 생성할 아이템 프리팹 (구급상자)
    public bool isGameClear = false;    // 게임 클리어 판단
    public int numItemPoint = 9;    // 아이템 포인트 개수
    int numItem = 0;    // 생성 아이템 개수


    // Kill Count 표시
    public Text killText;
    // 좀비를 죽인 횟수
    int killCount = 0;

    // Item Count 표시
    public Text itemText;
    // 아이템 먹은 횟수
    int itemCount = 0;



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

        // 하이러키 뷰의 ItemPointGroup을 찾아 하위에 있는 모든 Transform 컴포넌트를 찾아온다.
        itemPoints = GameObject.Find("ItemPointGroup").GetComponentsInChildren<Transform>();
        if (itemPoints.Length > 0) CreateItem();
        
        bool[] createItem = new bool[numItemPoint];    // 아이템 생성 위한 배열
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

    // 구급상자 아이템을 생성하는 함수
    void CreateItem()
    {
        for (int i = 0; i < numItemPoint; i++)
        {
            bool randItem = (Random.value > 0.5f);

            if (randItem)
            {
                Instantiate(item, itemPoints[i].position, itemPoints[i].rotation);
                numItem++;

                itemText.text = "Item(count/total) 0/" + numItem;
            }
            
        }
       
        // 만약 0개라면 가장 먼 위치에 생성
        if (numItem == 0) Instantiate(item, itemPoints[1].position, itemPoints[1].rotation);


        //if (isGameClear)
        //{
        //    // 재시작 버튼 활성화
        //    restartBtn.SetActive(true);
        //}
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

    public void AddItemCount()
    {
        ++itemCount;    // 개수 증가
        itemText.text = "Item(count/total) " + itemCount + "/" + numItem;
    }
}
