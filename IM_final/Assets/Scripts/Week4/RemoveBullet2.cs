using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveBullet2 : MonoBehaviour
{
    public GameObject sparkEffect;  // 충돌 효과 프리팹

    void OnCollisionEnter(Collision coll)
    {
        // 충돌한 게임오브젝트의 태그 비교
        if (coll.collider.tag == "BULLET")
        {
            GameObject spark = Instantiate(sparkEffect);        // 충돌 효과 생성
            spark.transform.position = coll.transform.position; // 충돌 위치 지정
            Destroy(spark, 1);  // 1초 후 충돌 효과 제거

            Destroy(coll.gameObject);   // 충돌한 오브젝트 제거
        }
    }
}
