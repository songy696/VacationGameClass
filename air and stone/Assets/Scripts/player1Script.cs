using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player1Script : MonoBehaviour
{
    public float speed;

    //public LayerMask groundLayer;
    //public Transform feet;
    //public Transform groundCheck;

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
        //.......................................................................................................Horizontal Movemenet
        float xHorizontal = Input.GetAxis("Horizontal2");
        //float xVertical = Input.GetAxis("Vertical2");

        //you put the speed variable here, with the horizontal movment, instead of the multiplying rb2d.velocity = movement * speed; (at the bottom) cause it creates the bug
        Vector2 movement = new Vector2(xHorizontal* speed, rb2d.velocity.y);

        // for the horizontal movement velocity works better than AddForce
        rb2d.velocity = movement;

        //.......................................................................................................Jump / Veritical Movment
        if (Input.GetButtonDown("Jump2") && isJump)
        {
            isJump = false;
            rb2d.AddForce(new Vector3(0, jumpForce, 0));
        }

        //this creates the floaty feeling while falling down
        if (rb2d.velocity.y < 0)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                rb2d.AddForce(new Vector3(0, 90, 0));
            }
            else {
                rb2d.AddForce(new Vector3(0, 0, 0));
            }
            //dont use the physic.gravityscale() because it changes the whole setting of the world, 
            //instead use addforce because it creates the compelling force up against the gravity that makes the slow fall :)

        }

        // changes the horizontal movement speed slow while in the air
        if (rb2d.velocity.y < 0 && isJump == false)
        {
            speed = 2.5f;
        }
        else {
            speed = 10f;
        }

        if (rb2d.velocity.y > 0 && isJump == false) {
            //yield WaitForSecond(0.25);
            speed = 5f;
        }



    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            //Debug.LogWarning("ground");
            
            isJump = true;
        }

        if (collision.gameObject.CompareTag("Spring"))
        {
                rb2d.AddForce(new Vector3(0, jumpForce * 1.3f, 0));

        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Knife")) {
            gameObject.SetActive(false);
        }

        if (collision.gameObject.CompareTag("Bullet")) {
            gameObject.SetActive(false);
        }
    }
}
