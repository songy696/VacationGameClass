using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecEnemyScript : MonoBehaviour
{
    public Transform bulletPoint;
    public BulletPoolScript Pool;

    private void OnEnable()
    {
        StartCoroutine(Fire());
    }

    public IEnumerator Fire() {
        while (true) {
            yield return new WaitForSeconds(.5f);
            BulletScript bullet = Pool.GetFromBulletPool();
            bullet.transform.position = bulletPoint.position;
        }
        
    }
}
