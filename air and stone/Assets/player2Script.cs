using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player2Script : MonoBehaviour
{
    public float speed;

    public float jumpForce;

    Rigidbody2D rb2d;


    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        float xHorizontal = Input.GetAxis("Horizontal");

        Vector2 g = new Vector2(xHorizontal, 0);

        rb2d.AddForce(g * speed);

        if (Input.GetButtonDown("Jump3"))
        {
            rb2d.AddForce(new Vector3(0, jumpForce, 0));

        }

    }
}
