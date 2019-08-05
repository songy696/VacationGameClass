using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


// the list what I have to do
//1. players clamped inside of the camera restriction
//2. fade in fade out of the players
//3. animations - players and the intro plays
//4. try wall jumps
//5. background drawings and stage designs
//6. UI of intro instructions what to do
//7. lighting
//8. waves for the bullet shooting
//9. hinge joint

public class player1Script : MonoBehaviour
{
    public float speed;
    public float jumpForce;

    Rigidbody2D rb2d;

    bool isJump;

    public int level = 3;
    public int health = 3;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        isJump = false;
    }

    public void SavePlayer() {
        SaveSystem.SavePlayer(this);
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        level = data.level;
        health = data.health;

        Vector3 position;
        position.x = data.position[0];
        position.x = data.position[1];
        position.x = data.position[2];
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
