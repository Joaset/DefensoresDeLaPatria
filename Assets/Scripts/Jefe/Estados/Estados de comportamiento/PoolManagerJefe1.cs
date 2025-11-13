using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManagerJefe1 : MonoBehaviour
{
    public static PoolManagerJefe1 instance;
    private Dictionary<string, Queue<GameObject>> poolDict = new Dictionary<string, Queue<GameObject>>();

    private void Awake()
    {
        instance = this;
    }

    public void CreatePool(string key, GameObject prefab, int count)
    {
        if (!poolDict.ContainsKey(key))
            poolDict[key] = new Queue<GameObject>();

        for (int i = 0; i < count; i++)
        {
            GameObject obj = Instantiate(prefab);
            obj.SetActive(false);
            poolDict[key].Enqueue(obj);
        }
    }

    public GameObject GetFromPool(string key)
    {
        if (!poolDict.ContainsKey(key)) return null;

        GameObject obj = poolDict[key].Dequeue();
        obj.SetActive(true);
        poolDict[key].Enqueue(obj); // vuelve al final del queue
        return obj;
    }
}
