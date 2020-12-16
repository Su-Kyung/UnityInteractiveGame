using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ex2_BarrelCtrl_Capsule : MonoBehaviour
{
    int hitCount = 0;   // 발사체에 맞은 횟수
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision coll)
    {
        if (coll.collider.CompareTag("BULLET"))
        {
            if (++hitCount == 3)    // 발사체에 3회 맞았다면
            {
                rb.AddForce(0, 10000, 0);   // 위로 힘을 가함
            }
        }
    }
}
