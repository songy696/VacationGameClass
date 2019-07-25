using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    public EnemyController Prefab;
    private List<EnemyController> Pool;

    public BoltPool EnemyBoltPool;

    void Start()
    {
        Pool = new List<EnemyController>();
    }

    public EnemyController GetFromPool()
    {
        for (int i = 0; i < Pool.Count; i++)
        {
            if (!Pool[i].gameObject.activeInHierarchy)
            {
                Pool[i].gameObject.SetActive(true);
                return Pool[i];
            }

        }

        EnemyController newOb = Instantiate(Prefab);
        newOb.SetUp(EnemyBoltPool);
        Pool.Add(newOb);
        return newOb;

    }

}
