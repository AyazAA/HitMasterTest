using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject _objectToPool;
    [SerializeField] private int _countToPool = 5;
    private List<GameObject> _poolObjects;

    private void Start()
    {
        _poolObjects = new List<GameObject>();
        for (int i = 0; i < _countToPool; i++)
        {
            CreateNewObject();
        }
    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < _countToPool; i++)
        {
            if (!_poolObjects[i].activeInHierarchy)
            {
                return _poolObjects[i];
            }
        }
        return CreateNewObject();
    }

    private GameObject CreateNewObject()
    {
        GameObject tmp = Instantiate(_objectToPool);
        tmp.SetActive(false);
        _poolObjects.Add(tmp);
        return tmp;
    }
}
