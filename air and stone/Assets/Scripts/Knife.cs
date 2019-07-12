using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
{
    //public float startPoint;
    //public float endPoint;
    //static float t = 0f;

    public float upSpeed;
    public float downSpeed;

    public float startPoint;
    public float endPoint;

    private bool flag;

    Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        //Vector
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        

        if (flag)
        {
            rb2d.velocity = new Vector2(0, -downSpeed);



        }
        else
        {
            rb2d.velocity = new Vector2(0, upSpeed);
        }

        transform.position = new Vector2(transform.position.x, Mathf.Clamp(transform.position.y, endPoint, startPoint));
        //transform.position = new Vector3(-9.35f, Mathf.Lerp(startPoint, endPoint, t), 0);
    }

    public void SetFlag(bool value)
    {
        flag = value;
    }
}
