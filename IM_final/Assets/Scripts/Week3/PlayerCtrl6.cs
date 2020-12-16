using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl6 : MonoBehaviour
{
    // Start is called before the first frame update

    public float moveSpeed = 10;
    public float rotSpeed = 100;
    public float force = 300;
    Vector3 AXIS_X = new Vector3(1, 0, 0);
    Vector3 AXIS_Y = new Vector3(0, 1, 0);
    Vector3 AXIS_Z = new Vector3(0, 0, 1);

    Rigidbody rb;
    Transform tr;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        tr = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Rotate();
        Jump();
    }

    void Move()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 moveDir = (AXIS_X * h + AXIS_Z * v).normalized;

        tr.Translate(moveDir * moveSpeed * Time.deltaTime, Space.Self);
    }

    void Rotate()
    {
        float mx = Input.GetAxis("Mouse X");

        Vector3 rotY = AXIS_Y * mx * rotSpeed * Time.deltaTime;

        tr.Rotate(rotY, Space.World);
    }

    void Jump()
    {
        {
            if (Input.GetKeyDown("space"))
            {
                rb.AddForce(0, force, 0);
            }
        }
    }
    void OnDisable()
    {

        GetComponent<Renderer>().material.color = Color.black;

        rb.velocity = Vector3.zero;
        rb.AddForce(0, 5000, 0);

    }
}