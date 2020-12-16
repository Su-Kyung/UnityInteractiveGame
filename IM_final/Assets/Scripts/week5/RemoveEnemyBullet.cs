using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveEnemyBullet : MonoBehaviour
{

    public GameObject sparkEffect;

    void OnCollisionEnter(Collision coll)
    {
        if (coll.collider.tag == "BULLET2")
        {
            GameObject spark = Instantiate(sparkEffect);
            spark.transform.position = coll.transform.position;  //충돌한 지점의 위치에 이 이펙트가 뿌려주는것
            spark.transform.localScale *= 0.5f;
            Destroy(spark, 1);

            Destroy(coll.gameObject);  //발사체 제거

        }
    }
}
