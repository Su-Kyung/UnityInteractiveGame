﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class w9_PlayerCtrl : MonoBehaviour
{
    // 이동 속도 변수
    public float moveSpeed = 10.0f;
    // 회전 속도 변수
    public float rotSpeed = 80.0f;

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        float r = Input.GetAxis("Mouse X");

        // 전후좌우 이동 방향 벡터 계산
        Vector3 moveDir = (Vector3.forward * v) + (Vector3.right * h);
        // Translate (이동 방향 * 속도 * 변위값 * Time.deltaTime, 기준좌표)
        transform.Translate(moveDir.normalized * moveSpeed * Time.deltaTime, Space.Self);
        // Vector3.up 축을 기준으로 rotSpeed 만큼의 속도로 회전
        transform.Rotate(Vector3.up * rotSpeed * Time.deltaTime * r);
    }
}