using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{

    public float countDown;

    private void OnEnable()
    {
        StartCoroutine(StartTimer());
    }

    private IEnumerator StartTimer() {
        yield return new WaitForSeconds(countDown);
        gameObject.SetActive(false);
    }
}
