using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputMouse2 : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            print("좌측 버튼 눌렀음");
        }

        if (Input.GetMouseButtonUp(0))
        {
            print("좌측 버튼 떼었음");
        }
    }
}
