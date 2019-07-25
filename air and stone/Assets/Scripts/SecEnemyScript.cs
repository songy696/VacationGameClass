using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecEnemyScript : MonoBehaviour
{
    public Transform bulletPoint;
    public BulletPoolScript Pool;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        StartCoroutine(Fire());
    }

    public IEnumerator Fire() {
        while (true) {
            yield return new WaitForSeconds(0.5f);
            BulletScript bullet = Pool.GetFromBulletPool();
            bullet.transform.position = bulletPoint.position;
        }
        
    }
}
