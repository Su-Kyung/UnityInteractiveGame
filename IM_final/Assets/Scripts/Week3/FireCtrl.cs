using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCtrl : MonoBehaviour
{
    public GameObject bullet;   // 총알 프리팹
    public Transform firePos;   // 총알 발사좌표

    // Update is called once per frame
    void Update()
    {
        // 마우스 왼쪽 버튼 클릭
        if (Input.GetMouseButtonDown(0))
        {
            // firePos의 위치 및 방향으로 발사체 생성
            GameObject obj = Instantiate(bullet, firePos.position, firePos.rotation);
            Destroy(obj, 3.0f); // 3초 후 자동 소멸
        }
    }
}
