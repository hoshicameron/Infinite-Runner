using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : SingletonMonoBehaviour<PoolManager>
{
    [System.Serializable]
    public class pool
    {
        public int poolSize;
        public GameObject prefab;
    }

    [SerializeField] private pool[] pools;
    [SerializeField] private Transform parent;

    private Dictionary<int,Queue<GameObject>> poolDictoiDictionary=new Dictionary<int, Queue<GameObject>>();

    private void Start()
    {
        for (int i = 0; i < pools.Length; i++)
        {
            CreatePool(pools[i].prefab, pools[i].poolSize);
        }
    }

    private void CreatePool(GameObject prefab, int poolSize)
    {
        int poolKey = prefab.GetInstanceID();
        string prefabName = prefab.name;

        GameObject parentGameObject=new GameObject("Anchor"+prefabName);

        if (!poolDictoiDictionary.ContainsKey(poolKey))
        {
            poolDictoiDictionary.Add(poolKey,new Queue<GameObject>());

            for (int i = 0; i < poolSize; i++)
            {
                GameObject newGameObject = Instantiate(prefab,parentGameObject.transform) as GameObject;
                newGameObject.SetActive(false);

                poolDictoiDictionary[poolKey].Enqueue(newGameObject);
            }
        }
    }

    public GameObject ReuseGameObject(GameObject prefab, Vector3 position, Quaternion rotation)
    {
        int poolKey = prefab.GetInstanceID();

        if (poolDictoiDictionary.ContainsKey(poolKey))
        {
            GameObject objectToReuse = GetObjectFromPool(poolKey);

            ResetObject(position, rotation, objectToReuse, prefab);

            return objectToReuse;
        } else
        {
            Debug.Log("No object pool for "+ prefab);
            return null;
        }
    }

    private GameObject GetObjectFromPool(int poolKey)
    {
        GameObject objectToReuse = poolDictoiDictionary[poolKey].Dequeue();
        poolDictoiDictionary[poolKey].Enqueue(objectToReuse);

        if(objectToReuse.activeSelf==true)
            objectToReuse.SetActive(false);

        return objectToReuse;
    }

    private void ResetObject(Vector3 position, Quaternion rotation, GameObject objectToReuse, GameObject prefab)
    {
        objectToReuse.transform.position = position;
        objectToReuse.transform.rotation = rotation;

        objectToReuse.transform.localScale = prefab.transform.localScale;

    }
}
