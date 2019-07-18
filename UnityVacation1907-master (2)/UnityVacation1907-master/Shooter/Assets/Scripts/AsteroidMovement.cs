using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMovement : MonoBehaviour
{

    private Rigidbody rb;

    public float Speed = 5;

    //should use awake because onenable works before start therefore it should be before
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = Vector3.back * Speed;
    }

    //this works like a switch that it works when the objact is appeared
    void OnEnable()
    {
        rb.angularVelocity = Random.onUnitSphere * 3;//new Vector3(10, 20, 30);
    }

    // Start is called before the first frame update
    void Start()
    {

        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bolt") || 
            other.gameObject.CompareTag("Player")) {

            

            other.gameObject.SetActive(false);
            gameObject.SetActive(false);
        }
    }

}
