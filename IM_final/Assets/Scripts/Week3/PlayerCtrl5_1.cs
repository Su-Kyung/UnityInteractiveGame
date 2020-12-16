using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl5_1 : MonoBehaviour
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
        if (Mathf.Abs(rb.velocity.y) < 0.001f)
        {
            if (Input.GetKeyDown("space"))
            {
                rb.AddForce(0, force, 0);
            }
        }
    }
}
