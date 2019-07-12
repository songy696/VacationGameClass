using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Falling : MonoBehaviour
{

    Rigidbody2D rb;

    public float fallDelay = 2.0f;

    bool touched = false;
    
    bool showing;

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
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Player2")) {
            touched = true;
            StartCoroutine(Fall());
        }
    }

    IEnumerator Fall() {
        yield return new WaitForSeconds(fallDelay);
        GetComponent<Rigidbody2D>().isKinematic = false;
    }
    
    void Appear(bool show){
        showing = show;
    }
}

class Regenerating : MonoBehaviour
{
    public Falling falling;
    
    public flaot x;
    public flaot y;
    
    void Start() {
        Invoke(SpawnObject, 1);
    }
    
    void SpawnObject(){
        Instantiate(falling.Fall, new Vecotr2(x, y), Quaternion.identity);
    }
}
