using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyScript : MonoBehaviour
{

    public  Transform[] PatrolPoints;
    public Transform enemy;
    private Transform playerPos;
    public float enemySpeed;

    private int destPoint = 0;
    public float patrolSpeed;
    int targetSpots;
    float distToSpot = 0.02f;

    int Round;

    private float waitTime;

    //private NavMeshAgent agent;

    Vector3 currentPosition;

    void Start()
    {
        targetSpots = 0;

        waitTime = Random.Range(1f,3f);

        //StartCoroutine(TrailEnemies());
        playerPos = GameObject.FindGameObjectWithTag("Player2").transform;
        //agent = GetComponent<NavMeshAgent>();
        //agent.autoBraking = false;

    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, playerPos.position);

        if (distance <= 5)
        {
            transform.position = Vector2.MoveTowards(transform.position, playerPos.position, enemySpeed * Time.deltaTime);
        }
        //else {
        //    Patrol();
        //}

        
    }

    void Patrol()
    {
        //// Returns if no points have been set up
        //if (PatrolPoints.Length == 0)
        //    return;

        //// Set the agent to go to the currently selected destination.
        //agent.destination = PatrolPoints[destPoint].position;

        //// Choose the next point in the array as the destination,
        //// cycling to the start if necessary.
        //destPoint = (destPoint + 1) % PatrolPoints.Length;



        //if (Vector2.Distance(transform.position, PatrolPoints[targetSpots].position) < distToSpot){
        //        Round++;
        //        targetSpots++;

        //        if (targetSpots > PatrolPoints.Length - 1)
        //        {
        //            targetSpots = 0;
        //        }
        //}
    }
}
