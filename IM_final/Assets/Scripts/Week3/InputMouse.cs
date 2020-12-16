using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputMouse : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            print("마우스 좌측 버튼");
        }
        
        if (Input.GetMouseButton(1))
        {
            print("마우스 우측 버튼");
        }

        if (Input.GetMouseButton(2))
        {
            print("마우스 중간 버튼");
        }
    }
}
