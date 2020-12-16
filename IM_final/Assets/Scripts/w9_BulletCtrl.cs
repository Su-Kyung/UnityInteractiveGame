using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class w9_BulletCtrl : MonoBehaviour
{
    // 총알의 파괴력
    public float damage = 20.0f;
    // 총알 발사 속도
    public float speed = 1000.0f;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().AddForce(transform.forward * speed);
        Destroy(gameObject, 1.0f);  // 가까이 있을 때만 공격 가능하도록 1초뒤 파괴
    }
}
