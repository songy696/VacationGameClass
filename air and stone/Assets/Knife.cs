using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
{
    public float startPoint;
    public float endPoint;

    bool inCol;


    static float t = 0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        //if (inCol)
        //{
            transform.position = new Vector3(-9.35f, Mathf.Lerp(startPoint, endPoint, t), 0);

            //t += 1f * Time.deltaTime;
        //}
    }

    //void OnTriggerEnter2D(Collider2D collision)
    //{

    //    if (collision.gameObject.CompareTag("Player"))
    //    {
    //        inCol = true;
    //    }
    //}
}
