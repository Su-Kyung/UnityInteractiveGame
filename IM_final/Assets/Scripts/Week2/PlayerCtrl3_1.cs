using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl3_1 : MonoBehaviour
{
    public float moveSpeed = 10.0f;
    float h = 0.0f;
    float v = 0.0f;
    Transform tr;

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
        float tx = h * moveSpeed * Time.deltaTime;
        float tz = v * moveSpeed * Time.deltaTime;
        tr.Translate(tx, 0, tz);
    }
}
