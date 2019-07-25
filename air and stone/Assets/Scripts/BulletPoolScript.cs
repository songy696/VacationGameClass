using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPoolScript : MonoBehaviour
{

    public BulletScript bulletPrefab;
    private List<BulletScript> Pool;


    // Start is called before the first frame update
    void Start()
    {
        Pool = new List<BulletScript>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public BulletScript GetFromBulletPool() {
        for (int i = 0; i < Pool.Count; i++)
        {
            if (!Pool[i].gameObject.activeInHierarchy)
            {
                Pool[i].gameObject.SetActive(true);
                return Pool[i];
            }
        }

        BulletScript obj = Instantiate(bulletPrefab);
        Pool.Add(obj);
        return obj;
    }
}

