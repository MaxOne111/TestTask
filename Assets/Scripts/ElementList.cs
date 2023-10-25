using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElementList : MovingUIPanel
{
    [SerializeField] private GameObject _Objects_Content;
    [SerializeField] private ListElement _Object_Prefab;
    
    private List<ListElement> _Elements = new List<ListElement>();
    private List<ObjectForManipulation> _Selected_Elements = new List<ObjectForManipulation>();
    
    private void Awake()
    {
        GameEvents._View_Current_Object += HideTab;
        GameEvents._View_Current_Object += HidePanel;
        
        GameEvents._View_All_Objects += ShowTab;
    }

    public void LoadListElements(ObjectForManipulation[] _objects)
    {
        for(int i = 0; i < _objects.Length; i++)
        {
            ListElement _element = Instantiate(_Object_Prefab, _Objects_Content.transform);
            _element.ObjectRef(_objects[i]);
            _Elements.Add(_element);
        }
    }

    public void SelectAllObjects(Toggle _checkbox)
    {
        if (_checkbox.isOn)
        {
            for (int i = 0; i < _Elements.Count; i++)
            {
                _Elements[i].SelectObject();
            }
        }
        else
        {
            for (int i = 0; i < _Elements.Count; i++)
            {
                _Elements[i].ResetObject();
            }
        }
    }

    public void ChangeTransparency(float _value)
    {
        if (_Selected_Elements.Count <= 0)
        {
            return;
        }

        for (int i = 0; i < _Selected_Elements.Count; i++)
        {
            _Selected_Elements[i].ChangeTransparency(_value);
        }
    }
    
    public void ChangeVisibility(Toggle _checkbox)
    {
        if (_Selected_Elements.Count <= 0)
        {
            return;
        }


        if (_checkbox.isOn)
        {
            for (int i = 0; i < _Selected_Elements.Count; i++)
            {
                _Selected_Elements[i].VisibilityOn();
            }
        }
        else
        {
            for (int i = 0; i < _Selected_Elements.Count; i++)
            {
                _Selected_Elements[i].VisibilityOff();
            }
        }
        
        for (int i = 0; i < _Elements.Count; i++)
        {
            _Elements[i].VisibilityStatus();
        }
        
    }

    public void AddElement(ObjectForManipulation _object)
    {
        _Selected_Elements?.Add(_object);
    }

    public void RemoveElement(ObjectForManipulation _object)
    {
        _Selected_Elements?.Remove(_object);
    }
    

    private void OnDisable()
    {
        GameEvents._View_Current_Object -= HideTab;
        GameEvents._View_Current_Object -= HidePanel;
        
        GameEvents._View_All_Objects -= ShowTab;
    }
}
