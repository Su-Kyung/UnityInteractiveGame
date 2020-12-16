using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Practice3 : MonoBehaviour
{
    private Transform tr;
    public float rotSpeed = 100.0f;
    public float moveSpeed = 50.0f;
    Vector3 axisY = new Vector3(1, 0, 0);
    Vector3 axisX = new Vector3(0, 0, 1);

    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        // 이동
        float mx = Input.GetAxis("Mouse X");
        float my = Input.GetAxis("Mouse Y");

        // 회전
        float msw = Input.GetAxis("Mouse ScrollWheel");
        
        // 이동
        Vector3 moveZ = axisY * mx * moveSpeed * Time.deltaTime;
        Vector3 moveX = axisX * my * moveSpeed * Time.deltaTime;

        tr.Translate(moveZ, Space.World);
        tr.Translate(moveX, Space.World);

        // 회전
        tr.Rotate(0, msw * rotSpeed, 0, Space.World);
    }
}
