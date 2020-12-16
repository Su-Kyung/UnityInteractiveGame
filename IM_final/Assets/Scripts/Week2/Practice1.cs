using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Practice1 : MonoBehaviour
{
    public float moveSpeed = 10.0f;
    public float rotSpeed = 500.0f;
    float h = 0.0f;
    float v = 0.0f;

    Transform tr;
    Vector3 axisY = new Vector3(0, 1, 0);   // Y축 회전 벡터
    Vector3 moveVer = new Vector3(0, 0, 1); // 앞뒤 이동 벡터

    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        Vector3 rotY = axisY * h * rotSpeed * Time.deltaTime;
        Vector3 moveDir = (moveVer * v).normalized;

        tr.Rotate(rotY, Space.World);
        tr.Translate(moveDir * moveSpeed * Time.deltaTime, Space.World);
    }
}
