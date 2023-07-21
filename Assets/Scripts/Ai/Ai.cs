using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Ai : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;

    GameObject destination1;
    EnemyState enemyState;
    float distance = 100;

    void Start()
    {
        destination1 = GameObject.Find("Player");
        enemyState = gameObject.GetComponent<EnemyState>();
    }

    void Update()
    {
        if (enemyState.isDead || enemyState.isAtacking)
        {
            navMeshAgent.destination = transform.position;
        }
        else
        {
            navMeshAgent.destination = destination1.transform.position;
        }

        distance = Vector3.Distance(transform.position, destination1.transform.position);

        if (distance <= 3 && !enemyState.isDead)
        {
            enemyState.isAtacking = true;
        }
        else
        {
            enemyState.isAtacking = false;
        }
    }
}
