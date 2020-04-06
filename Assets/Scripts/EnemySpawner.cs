using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public static float enemyCount = 0;
    public Transform player;
    void Start()
    {
        StartCoroutine(SpawnCycle());
    }

    IEnumerator SpawnCycle()
    {
        while(true)
        {
            yield return new WaitForSeconds(3);
            if(enemyCount < ObjectPooler.instance.pools[1].size)
            {
                GameObject enemy = ObjectPooler.instance.SpawnFromPool(ObjectPooler.PoolType.EnemyMinion, transform.position, Quaternion.identity);
                enemy.GetComponent<EnemyController>().target = player;
                enemyCount++;
            }
        }
    }
}
