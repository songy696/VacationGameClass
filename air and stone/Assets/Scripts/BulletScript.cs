using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{

    private Rigidbody2D rb2d;

    public float Hspeed;
    public float Vspeed;

    public void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        //rb2d.velocity = Vector2.zero;
        rb2d.AddForce(new Vector2(Random.Range(-25f, 25f) * Hspeed, 
                                  Random.Range(50f, 100f) * Vspeed));
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            gameObject.SetActive(false);
        }
    }

}
