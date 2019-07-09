using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player1Script : MonoBehaviour
{
    public float speed;

    public float jumpForce;

    Rigidbody2D rb2d;

    bool isJump;

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
        float xHorizontal = Input.GetAxis("Horizontal2");

        float xVertical = Input.GetAxis("Vertical2");

        Vector2 g = new Vector2(xHorizontal, xVertical);

        rb2d.AddForce(g * speed);

        if (Input.GetButtonDown("Jump2"))
        {
            rb2d.AddForce(new Vector3(0, jumpForce, 0));

        }

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
}
