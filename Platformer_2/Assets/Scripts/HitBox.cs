using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox : MonoBehaviour
{
    public int TargetHitCount;
    public int currentHitCount;

    private BoxCollider2D mCollider;

    void Start()
    {
        currentHitCount = 0;
        mCollider = GetComponent<BoxCollider2D>();
    }

    public void Hit(int value)
    {
        Debug.Log(value);
        currentHitCount++;
        if (currentHitCount == TargetHitCount) {
            StartCoroutine(CheckUp());
        }
    }

    private IEnumerator CheckUp() {
        yield return new WaitForSeconds(5);
        if (currentHitCount == TargetHitCount) {
            Debug.Log("NextStage");
            mCollider.enabled = false;
        }
    }


}
