using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class g1_BulletCtrl : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponentInChildren<ParticleSystem>().Play();

        Destroy(gameObject, 2);
    }
}
