using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    private GameObject Wall;

    // Start is called before the first frame update
    void Start()
    {
        Wall = GameObject.FindGameObjectWithTag("Wall");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || 
            collision.gameObject.CompareTag("Player2")) {
            Wall.SetActive(false);
            this.gameObject.SetActive(false);
        }
    }
}
