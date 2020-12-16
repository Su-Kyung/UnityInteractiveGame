using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ex1 : MonoBehaviour
{
    public float moveSpeed = 10.0f;
    public float rotSpeed = 200.0f;
    public float force = 300;

    Vector3 AXIS_X = new Vector3(1, 0, 0);
    Vector3 AXIS_Y = new Vector3(0, 1, 0);
    Vector3 AXIS_Z = new Vector3(0, 0, 1);

    Transform tr;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Rotate();
        Jump();
    }

    // 평면 이동
    void Move()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 moveDir = (AXIS_X * h + AXIS_Z * v).normalized;
        tr.Translate(moveDir * moveSpeed * Time.deltaTime, Space.Self);
    }

    // Y축 회전
    void Rotate()
    {
        float mx = Input.GetAxis("Mouse X");

        Vector3 rotY = AXIS_Y * mx * rotSpeed * Time.deltaTime;
        tr.Rotate(rotY, Space.World);
    }

    // 점프
    void Jump()
    {
        if (Input.GetKeyDown("space"))
        {
            rb.AddForce(0, force, 0);
        }
    }
}
