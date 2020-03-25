using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    public enum PoolType
    {
        Pellet,
        Bullet
    }

    [System.Serializable]
    public class Pool
    {
        public PoolType tag;
        public GameObject prefab;
        public int size;
    }

    //TODO: Convert to either a true singleton or to a static class
    public static ObjectPooler instance;
    void Awake()
    {
        instance = this;
    }


    public List<Pool> pools;
    public Dictionary<PoolType, Queue<GameObject>> poolDictionary;

    // Start is called before the first frame update
    void Start()
    {
        poolDictionary = new Dictionary<PoolType, Queue<GameObject>>();

        foreach (var pool in pools)
        {
            Queue<GameObject> objPool = new Queue<GameObject>();

            for(int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                objPool.Enqueue(obj);
            }

            poolDictionary.Add(pool.tag, objPool);
        }
    }

    public GameObject SpawnFromPool(PoolType tag, Vector3 position, Quaternion rotation)
    {
        GameObject objToSpawn = poolDictionary[tag].Dequeue();
        objToSpawn.transform.position = position;
        objToSpawn.transform.rotation = rotation;

        objToSpawn.SetActive(true);

        poolDictionary[tag].Enqueue(objToSpawn);
        
        return objToSpawn;
    }
}
