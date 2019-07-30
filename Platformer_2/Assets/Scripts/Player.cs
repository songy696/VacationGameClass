using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Animator mAnim;
    private Rigidbody2D mRB2D;

    public float speed;
    public float jumpSpeed;

    private bool mbGround;

    // Start is called before the first frame update
    void Start()
    {
        mAnim = GetComponent<Animator>();
        mRB2D = GetComponent<Rigidbody2D>();
        mbGround = true;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");

        if (horizontal > 0)
        { 
            transform.rotation = Quaternion.Euler(0, 0, 0);
            mAnim.SetBool(AnimHash.Walk, true);
        }
        else if (horizontal < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            mAnim.SetBool(AnimHash.Walk, true);
        }
        else
        {
            mAnim.SetBool(AnimHash.Walk, false);
        }

        mRB2D.velocity = new Vector2(horizontal * speed, mRB2D.velocity.y);

        //if you want to create the double or triple jumps, it is effective to use the int count down and reset the int.
        if (Input.GetButtonDown("Jump") && mbGround)
        {
            //sometimes it is better to use velocity than AddForce()because it is difficult know the right jumpforce
            mRB2D.velocity += new Vector2(0, jumpSpeed);
            //mRB2D.AddForce(new Vector2(0, 200));
            mbGround = false;

        }
        mAnim.SetFloat(AnimHash.Jump, mRB2D.velocity.y);

        //else{

        //}


        if (Input.GetButtonDown("Fire1"))
        {
            mAnim.SetBool(AnimHash.Melee, true);
        }
        if (Input.GetButtonUp("Fire1"))
        {
            mAnim.SetBool(AnimHash.Melee, false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") && collision.enabled) {
            mbGround = true;
        }
    }
}
