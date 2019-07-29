using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroller : MonoBehaviour
{

    private Rigidbody rb;
    bool isTouched;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void SetSpeed(float inputSpeed) {
        rb.velocity = Vector3.back * inputSpeed;
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
