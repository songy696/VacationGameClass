using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyScript : MonoBehaviour
{

    public GameObject[] TrailPoints;
    public Transform enemy;

    void Awake()
    {
        StartCoroutine(TrailEnemies());
    }

    IEnumerator TrailEnemies() {

        while (true) {
            yield return new WaitForSeconds(Random.Range(0.5f, 1f));
            TrailEnemy();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void TrailEnemy()
    {
        TrailPoints = GameObject.FindGameObjectsWithTag("TrailPoints");

        GameObject randomEnemyTrails = TrailPoints[Random.Range(0, TrailPoints.Length)];

        Vector3 TrailPath = transform.position;

        TrailPath = new Vector3(10, 0, 0);
    }

}
