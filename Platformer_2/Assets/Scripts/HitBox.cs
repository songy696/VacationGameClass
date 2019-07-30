using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox : MonoBehaviour
{
    public int TargetHitCount;
    public int currentHitCount;

    

    void Start()
    {
        currentHitCount = 0;
    }

    public void Hit(int value)
    {
        currentHitCount++;
        if (currentHitCount == TargetHitCount) {
            StartCoroutine(CheckUp());
        }
    }

    private IEnumerator CheckUp() {
        yield return new WaitForSeconds(5);
        if (currentHitCount == TargetHitCount) {
            Debug.Log("NextStage");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if () { }
    }
}
