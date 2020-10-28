using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// TODO 1: 플레이어의 움직임 control.
//          방향키 방향대로 움직이며, 마우스로 방향 회전
// TODO 2: 아이템과의 충돌 처리
public class g2_PlayerCtrl : MonoBehaviour
{
    // 플레이어의 움직임 컨트롤
    public float moveSpeed = 10;
    public float rotSpeed = 100;
    public float force = 300;
    Vector3 AXIS_X = new Vector3(1, 0, 0);
    Vector3 AXIS_Y = new Vector3(0, 1, 0);
    Vector3 AXIS_Z = new Vector3(0, 0, 1);

    // 아이템과의 충돌 시 플레이할 오디오 소스
    public AudioClip correctSnd;
    public AudioClip wrongSnd;
    private AudioSource ads;

    Rigidbody rb;
    Transform tr;

    // UI 및 점수
    public Text scoreText;
    public Text chanceText;
    public GameObject gameClear;    // 게임 클리어 UI
    public GameObject gameOver;
    public int endScore = 150;  // 종료 점수

    int score = 0;
    int chance = 5;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        tr = GetComponent<Transform>();
        ads = GetComponent<AudioSource>();      //
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Rotate();
        Jump();
    }

    // 키보드 입력에 따른 움직임
    void Move()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 moveDir = (AXIS_X * h + AXIS_Z * v).normalized;

        tr.Translate(moveDir * moveSpeed * Time.deltaTime, Space.Self);
    }

    // 마우스 움직이는 방향대로 플레이어 회전
    void Rotate()
    {
        float mx = Input.GetAxis("Mouse X");

        Vector3 rotY = AXIS_Y * mx * rotSpeed * Time.deltaTime;

        tr.Rotate(rotY, Space.World);
    }

    // 스페이스바 누르면 점프
    void Jump()
    {
        {
            if (Input.GetKeyDown("space"))
            {
                rb.AddForce(0, force, 0);
            }
        }
    }

    // 플레이어와 아이템 충돌 처리 함수
    private void OnCollisionEnter(Collision coll)
    {
        Debug.Log(coll.gameObject.tag.ToString());

        if (coll.gameObject.tag.ToString() == "Item")
        {
            ads.PlayOneShot(correctSnd);
            Destroy(coll.gameObject);

            score += 10;
            scoreText.text = "점수 " + score;

            if (score >= endScore)              // 종료 점수이면
            {
                gameClear.SetActive(true);      // Game Clear 출력
            }
        }
        else if (coll.gameObject.tag.ToString() == "Bomb")
        {
            ads.PlayOneShot(wrongSnd);
            Destroy(coll.gameObject);

            --chance;
            chanceText.text = "기회 " + chance;

            if (chance <= 0)
            {
                gameOver.SetActive(true);
                Destroy(gameObject, 1);
            }
        }
    }
}
