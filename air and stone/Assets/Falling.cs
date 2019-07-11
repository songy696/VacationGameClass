using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Falling : MonoBehaviour
{

    Rigidbody2D rb;
    
    bool touched;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        if (touched)
        {
            rb.GetComponent<Rigidbody2D>().gravityScale = 1f;
        }
        else {
            rb.GetComponent<Rigidbody2D>().gravityScale = 0f;
        }

        if (position < -10) {
            gameObject.Destroy;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) {
            touched = true;
        }
    }
}
