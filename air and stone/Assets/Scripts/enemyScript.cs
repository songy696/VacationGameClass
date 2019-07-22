using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyScript : MonoBehaviour
{
    public Transform[] PatrolPoints;
    int stopSpots;
    private Transform targetPos;
    private Transform targetPos1;

    public float enemyChaseSpeed;
    public float enemyPatrolSpeed;

    public float chaseDist;
    private bool isPaused;

    float distToSpot = 0.2f;
    private float waitTime;
    private float startWait;

    //private NavMeshAgent agent;


    void Start()
    {
        targetPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        targetPos1 = GameObject.FindGameObjectWithTag("Player2").GetComponent<Transform>();

        //setting the intial spot as the first spot
        stopSpots = 0;
        startWait = Random.Range(0.1f, 2f);
        waitTime = startWait;

        //repeating the wait time 
        //InvokeRepeating("StopPatrol", 0, Random.Range(3f, 6f));

    }

    //void StopPatrol() {
    //    isPaused = !isPaused;
    //}

    void Update()
    {
        //if (!isPaused)
        //{
        //chasing the player
        if (Vector2.Distance(transform.position, targetPos.position) < chaseDist)
        {
            transform.position = Vector2.MoveTowards(new Vector3(transform.position.x, transform.position.y), 
                                                     new Vector3(targetPos.position.x, transform.position.y), 
                                                     enemyChaseSpeed * Time.deltaTime);
        }
        else if (Vector2.Distance(transform.position, targetPos1.position) < chaseDist)
        {
            transform.position = Vector2.MoveTowards(new Vector3(transform.position.x, transform.position.y),
                                                     new Vector3(targetPos1.position.x, transform.position.y),
                                                     enemyChaseSpeed * Time.deltaTime);
        }

        else
        {
            //patrol
            transform.position = Vector2.MoveTowards(transform.position, 
                                                     PatrolPoints[stopSpots].position, 
                                                     enemyPatrolSpeed * Time.deltaTime);

            //Wait in between
            if (Vector2.Distance(transform.position, PatrolPoints[stopSpots].position) < distToSpot)
            {
                if (waitTime <= 0)
                {
                    stopSpots++;
                    if (stopSpots > PatrolPoints.Length - 1)
                    {
                        stopSpots = 0;
                        //flip the sprite
                    }
                    else
                    {
                        //flip
                    }
                    waitTime = startWait;
                }
                else
                {
                    waitTime -= Time.deltaTime;
                }

            }
        }

    }
}
