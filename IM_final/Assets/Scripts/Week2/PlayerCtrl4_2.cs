using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl4_2 : MonoBehaviour
{
    private Transform tr;
    public float rotSpeed = 100.0f;
    Vector3 axisY = new Vector3(0, 1, 0);
    Vector3 axisX = new Vector3(1, 0, 0);

    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        float mx = Input.GetAxis("Mouse X");
        float my = Input.GetAxis("Mouse Y");

        Vector3 rotY = axisY * mx * rotSpeed * Time.deltaTime;
        Vector3 rotX = axisX * my * rotSpeed * Time.deltaTime;
        
        tr.Rotate(rotY, Space.World);
        tr.Rotate(rotX, Space.Self);
    }
}
