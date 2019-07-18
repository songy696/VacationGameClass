using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroller : MonoBehaviour
{

    private Rigidbody rb;


    public float Speed;
    bool isTouched;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = Vector3.back * Speed;
    }

    public void SetSpeed(float inputSpeed) {
        Speed = inputSpeed;
        rb.velocity = Vector3.back * Speed;
    }


    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bumper")) {
            transform.position = transform.position + (Vector3.forward * 40.96f);
            isTouched = true;
            Debug.Log(isTouched);
        }
    }
}
