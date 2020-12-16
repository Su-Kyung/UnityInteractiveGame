using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyAttack : MonoBehaviour
{
    public Transform playerTr;
    public GameObject bullet;
    public float shotInterval = 1.0f;

    float shotTime = 0;


    // Update is called once per frame
    void Update()
    {
        shotTime += Time.deltaTime;

        if (shotTime > shotInterval)
        {
            Attack();
            shotTime = 0;
        }
    }

    void Attack()
    {
        Vector3 fireDir = (playerTr.position - transform.position).normalized;

        GameObject obj = Instantiate(bullet);
        obj.transform.position = transform.position;
        obj.GetComponent<Rigidbody>().AddForce(fireDir * 500);

        Destroy(obj, 5);
    }
}
