using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObectPooling : MonoBehaviour
{
    [SerializeField] private List<GameObject> _pooledObjects;
    [SerializeField] private GameObject _objectToPool;
    [SerializeField] private int _amountToPool;

    public static ObectPooling Instance;

    private void Awake()
    {
        Instance = this;
    }
    
    void Start()
    {
        // Loop through list of pooled objects,deactivating them and adding them to the list 
        _pooledObjects = new List<GameObject>();

        for (int i = 0; i < _amountToPool; i++)
        {
            GameObject obj = (GameObject)Instantiate(_objectToPool);
            obj.SetActive(false);
            _pooledObjects.Add(obj);
            obj.transform.SetParent(this.transform);
        }
    }

    public GameObject GetPooledObject()
    {
        // For as many objects as are in the pooledObjects list
        for (int i = 0; i < _pooledObjects.Count; i++)
        {
            // if the pooled objects is NOT active, return that object 
            if (!_pooledObjects[i].activeInHierarchy)
            {
                return _pooledObjects[i];
            }
        }
        // otherwise, return null   
        return null;
    }



}
