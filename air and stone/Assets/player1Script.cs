using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player1Script : MonoBehaviour
{
    public float speed;

    public LayerMask groundLayer;
    public Transform feet;
    public Transform groundCheck;

    public float jumpForce;

    Rigidbody2D rb2d;

    bool isJump;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

        isJump = false;
    }

    // Update is called once per frame
    void Update()
    {
        //isJump = Physics2D.OverlapCircle(feet.position, .5f, groundLayer);
    }

    void FixedUpdate()
    {
        //.............................................................................Horizontal Movemenet
        float xHorizontal = Input.GetAxis("Horizontal2");
        //float xVertical = Input.GetAxis("Vertical2");

        //speed goes in here with horizontal movment instead of the multiplying rb2d.velocity = movement * speed; here cause it creates the bug that will slows down the jump force
        Vector2 movement = new Vector2(xHorizontal* speed, rb2d.velocity.y);

        // for the horizontal movement velocity works better than AddForce
        rb2d.velocity = movement;

        //.............................................................................Jump / Veritical Movment
        if (Input.GetButtonDown("Jump2") && isJump)
        {
            isJump = false;
            rb2d.AddForce(new Vector3(0, jumpForce, 0));
        }

        if (rb2d.velocity.y< 0)
        {
            Physics2D.gravity = new Vector2(0, -1f);
            speed = 2.5f;
        }
        

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            //Debug.LogWarning("ground");
            
            isJump = true;
        }
    }
}
