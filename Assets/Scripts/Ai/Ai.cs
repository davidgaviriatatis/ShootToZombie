using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Ai : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;

    GameObject destination1;
    float distance = 100;

    void Start()
    {
        destination1 = GameObject.Find("Player");
    }

    void Update()
    {
        if (gameObject.GetComponent<EnemyState>().isDead || gameObject.GetComponent<EnemyState>().isAtacking)
        {
            navMeshAgent.destination = transform.position;
        }
        else
        {
            navMeshAgent.destination = destination1.transform.position;
        }

        distance = Vector3.Distance(transform.position, destination1.transform.position);

        if (distance <= 3 && !gameObject.GetComponent<EnemyState>().isDead)
        {
            gameObject.GetComponent<EnemyState>().isAtacking = true;
        }
        else
        {
            gameObject.GetComponent<EnemyState>().isAtacking = false;
        }
    }
}
