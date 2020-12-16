using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    public GameObject expEffect;
    public AudioClip expSound;  //폭발음원
    public int deathNum = 5;

    int hitcount = 0;
    AudioSource ads;


    void Start()
    {
        ads = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision coll)
    {
        if (coll.collider.CompareTag("BULLET2"))
        {
            if (++hitcount == deathNum)
            {
                GetComponent<PlayerCtrl6>().enabled = false;
                GetComponentInChildren<PlayerCtrl3>().enabled = false;
                ExpPlayer(coll);
            }
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
