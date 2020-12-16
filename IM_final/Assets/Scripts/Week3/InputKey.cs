using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputKey : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        // 중괄호 쓰는것이 좋다
        if (Input.GetKey("left"))
            print("left");
        if (Input.GetKey("right"))
            print("right");
        if (Input.GetKey("up"))
            print("up");
        if (Input.GetKey("down"))
            print("down");
    }
}
