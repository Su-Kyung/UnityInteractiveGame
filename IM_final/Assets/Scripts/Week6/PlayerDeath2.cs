using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath2 : MonoBehaviour
{
    public GameObject expEffect;
    public AudioClip expSound;  //폭발음원
    public int deathNum = 5;
    public HealthMng hm;    // 체력 게이지 컴포넌트. 추가된 부분

    int hitCount = 0;
    AudioSource ads;


    void Start()
    {
        ads = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision coll)
    {
        if (coll.collider.CompareTag("BULLET2"))
        {
            if (++hitCount == deathNum)
            {
                GetComponent<PlayerCtrl6>().enabled = false;
                GetComponentInChildren<PlayerCtrl3>().enabled = false;
                ExpPlayer(coll);
            }

            float ratio = (float)hitCount / deathNum;
            hm.SetHealth(1 - ratio);
        }
    }
    void ExpPlayer(Collision coll)
    {

        GameObject effect = Instantiate(expEffect);
        effect.transform.position = coll.transform.position;
        Destroy(effect, 2);

        ads.PlayOneShot(expSound);
    }
}
