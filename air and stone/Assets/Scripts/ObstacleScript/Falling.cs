using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Falling : MonoBehaviour
{

    Rigidbody2D rb;

    public float fallDelay;


    //public int count;

    Vector3 oriPos;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        rb.isKinematic = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        oriPos = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (transform.position.y < -10)
        {
            gameObject.SetActive(false);
        }

        if (gameObject.activeInHierarchy == false) {
            gameObject.SetActive(true);
            transform.position = oriPos;
        }

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && collision.enabled) {
            StartCoroutine(Fall());
        }
    }

    IEnumerator Fall() {
        yield return new WaitForSeconds(fallDelay);
        rb.isKinematic = false;
    }

}
