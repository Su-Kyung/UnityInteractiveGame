using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyCtrl : MonoBehaviour
{
    public Transform playerTr;
    public GameObject bullet;
    public Transform[] wayPotins;



    public float traceDist = 15;
    public float attackDist = 10;
    public float shotInterval = 1.0f;

    int nextIndex = 0;
    NavMeshAgent agent;
    Renderer render;

    float shotTime = 0;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        render = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float dist = (playerTr.position - transform.position).magnitude;
        if (dist < attackDist)
        {
            shotTime += Time.deltaTime;

            if (shotTime > shotInterval)
            {
                Attack();
                shotTime = 0;
            }
            render.material.color = Color.red;
        }
        else if (dist < traceDist)
        {
            Move(playerTr.position);

            render.material.color = Color.yellow;
        }
        else
        {
            if (agent.remainingDistance < 1.0f && agent.velocity.magnitude < 0.5f) //목표지점도달했는지 확실히 알수 있음
            {
                nextIndex = Random.Range(0, wayPotins.Length);
                Move(wayPotins[nextIndex].position);
            }
            render.material.color = Color.yellow * 0.7f;
        }

    }

    void Move(Vector3 pos)
    {
        if (agent.isPathStale == false)
        {
            agent.destination = pos;
            agent.isStopped = false;
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

    void OnDisable()
    {
        agent.enabled = false;
        render.material.color = Color.black;
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        GetComponent<Rigidbody>().AddForce(0, 3000, 0);

    }
}
