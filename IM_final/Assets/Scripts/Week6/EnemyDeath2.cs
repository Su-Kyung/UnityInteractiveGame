using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath2 : MonoBehaviour
{
    public GameObject expEffect;
    public AudioClip expSound;  //폭발음원
    public int deathNum = 3;
    public ScoreMng sm; // 추가된 부분

    int hitcount = 0;
    AudioSource ads;


    void Start()
    {
        ads = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision coll)
    {
        if (coll.collider.CompareTag("BULLET"))
        {
            if (++hitcount == deathNum)
            {

                GetComponent<EnemyCtrl>().enabled = false;
                ExpEnemy();
                sm.AddScore(10);    // 추가된 부분
            }
        }
    }
    void ExpEnemy()
    {

        GameObject effect = Instantiate(expEffect);
        effect.transform.position = transform.position;
        Destroy(effect, 2.0f);

        ads.PlayOneShot(expSound);
    }
}
