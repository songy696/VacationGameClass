using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSystem : MonoBehaviour
{
    bool isNear;

    public Knife knife;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Player2"))
        {
            isNear = true;
            //knife.SetActive(true);
            Debug.Log(isNear);
            knife.SetFlag(true);

        }
        //else ()
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Player2"))
        {
            knife.SetFlag(false);
        }
    }
}
