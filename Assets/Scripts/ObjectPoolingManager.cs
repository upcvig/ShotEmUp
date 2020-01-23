using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ObjectPoolItem
{
    public int amount;
    public GameObject objectToPool;
    public bool shouldExpand;
}

public class ObjectPoolingManager : MonoBehaviour
{

    public static ObjectPoolingManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<ObjectPoolingManager>();
            }

            return _instance;
        }
    }

    private static ObjectPoolingManager _instance;

    [SerializeField]
    private List<ObjectPoolItem> _itemsToPool = new List<ObjectPoolItem>();

    private Dictionary<string, Stack<GameObject>> _items = new Dictionary<string, Stack<GameObject>>();

    private void Awake()
    {
        foreach (var item in _itemsToPool)
        {
            var gameObjectItem = item.objectToPool.GetComponent<PoolItem>();

            _items.Add(gameObjectItem.Name, new Stack<GameObject>());

            for (int i = 0; i < item.amount; i++)
            {
                var obj = Instantiate(item.objectToPool);
                obj.SetActive(false);
                _items[gameObjectItem.Name].Push(obj);
            }
        }
    }

    public GameObject InstantiatePoolItem(GameObject gameObj, Vector3 position, Quaternion rotation)
    {
        GameObject obj = null;

        var poolItem = gameObj.GetComponent<PoolItem>();

        if (poolItem != null && _items.ContainsKey(poolItem.Name))
        {
            var items = _items[poolItem.Name];

            if (items.Count > 0)
            {
                obj = items.Pop();

                obj.transform.position = position;
                obj.transform.rotation = rotation;
                obj.SetActive(true);
            }
            else
            {
                var poolItemFind =
                    _itemsToPool.Find(item =>
                    item.objectToPool.
                    GetComponent<PoolItem>().
                    Name.Equals(poolItem.Name));

                if (poolItemFind.shouldExpand)
                {
                    obj = Instantiate(
                        poolItemFind.objectToPool,
                        position,
                        rotation);
                }

            }
        }
        else
        {
            obj = Instantiate(
                gameObj,
                position,
                rotation);
        }

        return obj;
    }

    public void DestroyPoolItem(GameObject item)
    {
        var poolItem = item.GetComponent<PoolItem>();

        if (poolItem != null && _items.ContainsKey(poolItem.Name))
        {
            item.SetActive(false);
            _items[poolItem.Name].Push(item);
        }
        else
        {
            Destroy(item);
        }
    }


}
