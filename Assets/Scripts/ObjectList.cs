using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectList : MonoBehaviour
{
    [SerializeField] private ElementList _Element_List;
    [SerializeField] private ObjectForManipulation[] _Objects;

    private void Awake()
    {
        _Objects = GetObjects();
    }

    private void Start()
    {
        _Element_List.LoadListElements(_Objects);
    }

    private ObjectForManipulation[] GetObjects()
    {
        ObjectForManipulation[] _objects = transform.GetComponentsInChildren<ObjectForManipulation>();
        return _objects;
    }
}
