using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{

    private Rigidbody2D rb2d;

    public float Speed;

    // Start is called before the first frame update

    void Start()

    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = transform.TransformDirection(Random.Range(-2f,2f), Random.Range(1f, 2f), 0) * Speed;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            gameObject.SetActive(false);
        }
    }

}
