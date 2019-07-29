using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Animator mAnim;

    private Rigidbody2D rb2d;
    public float speed;
    public float jumpForce;
    bool isJump;

    void Start()
    {
        mAnim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        Vector2 move = new Vector2(horizontal * speed, rb2d.velocity.y);

        //................................................................................Horizontal Movement
        if (horizontal > 0)
        {
            rb2d.velocity = move;
            transform.rotation = Quaternion.Euler(0, 0, 0);
            mAnim.SetBool(AnimationHash.Walk, true);
        }
        else if (horizontal < 0)
        {
            rb2d.velocity = move;
            transform.rotation = Quaternion.Euler(0, 180, 0);
            mAnim.SetBool(AnimationHash.Walk, true);
        }
        else
        {
            mAnim.SetBool(AnimationHash.Walk, false);
        }

        //............................................................................................Jump
        if (Input.GetButtonDown("Jump") && isJump)
        {
            isJump = false;
            rb2d.AddForce(new Vector3(0, jumpForce, 0));
            //mAnim.SetBool(AnimationHash.Jump, false);
        }

        //............................................................................................Attack
        if (Input.GetButtonDown("Fire1"))
        {
            mAnim.SetBool(AnimationHash.Melee, true);
        }
        if(Input.GetButtonUp("Fire1")) {
            mAnim.SetBool(AnimationHash.Melee, false);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground")) {
            isJump = true;
        }
    }
}
