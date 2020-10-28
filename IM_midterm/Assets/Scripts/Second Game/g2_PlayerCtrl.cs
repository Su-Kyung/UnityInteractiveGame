using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO: 플레이어의 움직임 control.
// 방향키 방향대로 움직이며, 마우스로 방향 회전
public class g2_PlayerCtrl : MonoBehaviour
{
    public float moveSpeed = 10;
    public float rotSpeed = 100;
    public float force = 300;
    Vector3 AXIS_X = new Vector3(1, 0, 0);
    Vector3 AXIS_Y = new Vector3(0, 1, 0);
    Vector3 AXIS_Z = new Vector3(0, 0, 1);

    Rigidbody rb;
    Transform tr;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        tr = GetComponent<Transform>();
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
}
