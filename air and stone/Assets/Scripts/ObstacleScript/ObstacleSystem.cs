using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSystem : MonoBehaviour
{
    bool isNear;

    public Knife knife;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Player2"))
        {
            isNear = true;
            Debug.Log(isNear);
            knife.SetFlag(true);

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // a collision detection that will trigger the knife to go up
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Player2"))
        {
            knife.SetFlag(false);
        }
    }
}
