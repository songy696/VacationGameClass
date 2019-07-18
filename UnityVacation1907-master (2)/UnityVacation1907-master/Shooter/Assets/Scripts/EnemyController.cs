using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Rigidbody rb;

    public Transform BoltPos;
    private BoltPool mPool;

    private Transform mPlayerTransform;

    public float speed;

    //public float Delay = 0.5f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = Vector3.back * speed;

    }

    private void OnEnable()
    {
        StartCoroutine(AutoFire());
        //like getcomponenet dotn use too much because it becomes extremely heavy
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        mPlayerTransform = player.transform;

        StartCoroutine(SideMovement());
    }

    private IEnumerator AutoFire() {
        while (true) {      //the reseaon why while function used is because it wants to function the insided script to work infinitly //not only once
            yield return new WaitForSeconds(Random.Range(0.7f, 1.2f));
            Bolt bolt = mPool.GetFromPool();
            bolt.transform.position = BoltPos.position;
        }
    }

    public void SetUp(BoltPool pool) {
        mPool = pool;
    }


    private IEnumerator SideMovement() {
        while (true) {
            float playerX = mPlayerTransform.position.x;
            //Vector3 currentPos = transform.position; // you have to use vector3 inorder to function the transform.... if you dont not allowed to fuction it only reading the script
            Vector3 currentVel = rb.velocity;
            //currentPos.x = playerX;
            currentVel.x = playerX - currentVel.x;       // this is using velocity instead of transform
            //transform.position = currentPos;
            rb.velocity = currentVel;



            yield return new WaitForFixedUpdate();  // this is similar to yield return null; this means wait till other object spawns
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bolt") ||
            other.gameObject.CompareTag("Player"))
        {



            other.gameObject.SetActive(false);
            gameObject.SetActive(false);
        }

        //if (other.gameObject.CompareTag("Player")) {

        //}
    }
}
