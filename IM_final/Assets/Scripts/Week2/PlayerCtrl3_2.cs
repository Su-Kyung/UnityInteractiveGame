using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl3_2 : MonoBehaviour
{
    public float moveSpeed = 10.0f;
    float h = 0.0f;
    float v = 0.0f;
    Transform tr;
    Vector3 moveHor = new Vector3(1, 0, 0);
    Vector3 moveVer = new Vector3(0, 0, 1);

    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
        Vector3 moveDir = (moveHor * h + moveVer * v).normalized;
        tr.Translate(moveDir * moveSpeed * Time.deltaTime);
    }
}
