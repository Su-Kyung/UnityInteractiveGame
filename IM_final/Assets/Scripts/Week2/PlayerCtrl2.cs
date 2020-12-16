using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl2 : MonoBehaviour
{
    float mx = 0.0f;
    float my = 0.0f;
    float msw = 0.0f;

    // Update is called once per frame
    void Update()
    {
        mx = Input.GetAxis("Mouse X");
        my = Input.GetAxis("Mouse Y");
        msw = Input.GetAxis("Mouse ScrollWheel");

        print("mx = " + mx);
        print("my = " + my);
        print("msw = " + msw);
    }
}
