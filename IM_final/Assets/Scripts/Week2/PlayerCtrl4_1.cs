using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl4_1 : MonoBehaviour
{
    private Transform tr;
    public float rotSpeed = 100.0f;

    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        float msw = Input.GetAxis("Mouse ScrollWheel");
        
        tr.Rotate(msw * rotSpeed, 0, 0, Space.World);
    }
}
