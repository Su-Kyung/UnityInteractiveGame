using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl5 : MonoBehaviour
{
    public float force = 300;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            rb.AddForce(0, force, 0);
        }
    }
}
