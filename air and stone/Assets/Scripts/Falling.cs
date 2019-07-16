﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Falling : MonoBehaviour
{

    Rigidbody2D rb;

    public float fallDelay = 2.0f;

    bool touched = false;

    public int count;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        if (transform.position.y < -10)
        {
            gameObject.SetActive(false);
            //Destroy(gameObject);
        }



    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) {
            touched = true;
        }
    }

    IEnumerator Fall() {
        yield return new WaitForSeconds(fallDelay);
        GetComponent<Rigidbody2D>().isKinematic = false;
    }

}
