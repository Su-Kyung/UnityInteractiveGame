using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Cannon 마우스 수직 방향 움직임에 따라 상하로 방향 전환
public class ex2_CannonCtrl : MonoBehaviour
{
    public float rotSpeed = 150.0f;
    Vector3 AXIS_X = new Vector3(-1, 0, 0);
    Transform tr;

    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        float my = Input.GetAxis("Mouse Y");

        Vector3 rotX = AXIS_X * my * rotSpeed * Time.deltaTime;
        tr.Rotate(rotX, Space.Self);
    }
}
