using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringScript : MonoBehaviour
{

    private Rigidbody2D rb2d;

    public float pushForce;

    public float pushForce2;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisonEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Player"))
        {
            rb2d.AddForce(new Vector3(0, pushForce, 0));
        }

        if (collision.gameObject.CompareTag("Player2"))
        {
            rb2d.AddForce(new Vector3(0, pushForce2, 0));
        }
    }

}
