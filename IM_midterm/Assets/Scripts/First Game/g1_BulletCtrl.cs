using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO: 발사체 -> 과녁 Collider에 닿으면 과녁에 꽂아지고, 2초 뒤에 사라짐
public class g1_BulletCtrl : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponentInChildren<ParticleSystem>().Play();

        Destroy(gameObject, 2);
    }
}
