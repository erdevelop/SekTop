﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    public static ObjectPooler SharedInstance;

    public List<GameObject> pooledObjects;
    public GameObject objectToPool;
    public int amountToPool;

    public List<GameObject> pooledObjects2;
    public GameObject objectToPool2;
    public int amountToPool2;

    void Awake()
    {
        SharedInstance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        // Loop through list of pooled objects,deactivating them and adding them to the list 
        pooledObjects = new List<GameObject>();
        for (int i = 0; i < amountToPool; i++)
        {
            GameObject obj = (GameObject)Instantiate(objectToPool);
            obj.SetActive(false);
            pooledObjects.Add(obj);
            obj.transform.SetParent(this.transform); // set as children of Spawn Manager
        }

        pooledObjects2 = new List<GameObject>();
        for (int i = 0; i < amountToPool2; i++)
        {
            GameObject obj2 = (GameObject)Instantiate(objectToPool2);
            obj2.SetActive(false);
            pooledObjects2.Add(obj2);
            obj2.transform.SetParent(this.transform); // set as children of Spawn Manager
        }
    }

    public GameObject GetPooledObject()
    {
        // For as many objects as are in the pooledObjects list
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            // if the pooled objects is NOT active, return that object 
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }
        // otherwise, return null   
        return null;
    }

    public GameObject GetPooledObject2()
    {
        // For as many objects as are in the pooledObjects list
        for (int i = 0; i < pooledObjects2.Count; i++)
        {
            // if the pooled objects is NOT active, return that object 
            if (!pooledObjects2[i].activeInHierarchy)
            {
                return pooledObjects2[i];
            }
        }
        // otherwise, return null   
        return null;
    }
}
