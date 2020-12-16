using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveBullet : MonoBehaviour
{
    void OnCollisionEnter(Collision coll)
    {
        // 충돌한 게임오브젝트의 태그값 비교
        if (coll.collider.tag == "BULLET")
        {
            // 충돌한 게임오브젝트 삭제
            Destroy(coll.gameObject);
        }
    }
}
