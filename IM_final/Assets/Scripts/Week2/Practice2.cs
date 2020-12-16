using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Practice2 : MonoBehaviour
{
    public float moveSpeed = 10.0f;
    public float rotSpeed = 500.0f;
    float h = 0.0f;
    float v = 0.0f;

    Transform tr;
    Vector3 moveHor = new Vector3(1, 0, 0); // 이동 벡터
    Vector3 moveVer = new Vector3(0, 0, 1); // 이동 벡터
    Vector3 axisY = new Vector3(0, 1, 0);   // 회전 벡터

    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        // 이동
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
        // 회전
        float mx = Input.GetAxis("Mouse X");

        // 이동
        Vector3 moveDir = (moveHor * h + moveVer * v).normalized;
        tr.Translate(moveDir * moveSpeed * Time.deltaTime, Space.World);

        // 회전
        Vector3 rotY = axisY * mx * rotSpeed * Time.deltaTime;
        tr.Rotate(rotY, Space.World);
    }
}
