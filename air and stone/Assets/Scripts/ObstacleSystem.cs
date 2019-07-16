using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSystem : MonoBehaviour
{
    bool isNear;

    public Knife knife;

    //Falling fallingPlats;

    //public GameObject fallingPrefab;

    //private int count = 3;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (fallingPlats.gameObject.activeInHierarchy == false)
        //{
        //    Spawn();
        //}
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
        // a collision detection that will trigger the knife to go up
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Player2"))
        {
            knife.SetFlag(false);
        }
    }

    public void Spawn ()
    {
        //count--;
        //if (count >= 0)
        //{
            //Instantiate(fallPlatPrefab);

           // fallingPrefab.gameObject.SetActive(true);
            //yield return new WaitForSeconds(.5f);
       // }
    }
}
