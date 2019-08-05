using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player2Script : MonoBehaviour
{
    public float speed;

    public float jumpForce;

    Rigidbody2D rb2d;

    bool isJump;

    bool onSpring;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

        isJump = false;

        onSpring = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        float xHorizontal = Input.GetAxis("Horizontal");

        Vector2 g = new Vector2(xHorizontal * speed, rb2d.velocity.y);

        rb2d.velocity = g;

        if (Input.GetButtonDown("Jump3") && isJump)
        {
            isJump = false;
            rb2d.AddForce(new Vector3(0, jumpForce, 0));
        }

        if (Input.GetButtonDown("Jump3") && onSpring)
        {
            onSpring = false;
            rb2d.AddForce(new Vector3(0, jumpForce * 2f, 0));
        }



    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground")) {
            isJump = true;
        }

        if (collision.gameObject.CompareTag("Spring"))
        {
            onSpring = true;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Knife"))
        {
            gameObject.SetActive(false);
        }

        if (collision.gameObject.CompareTag("Bullet"))
        {
            gameObject.SetActive(false);
        }
    }
}
