using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ListElement : MonoBehaviour
{
    private ElementList _Element_List;
    [SerializeField] private TextMeshProUGUI _Object_Name;
    [SerializeField] private ObjectForManipulation _Object_Ref;
    [SerializeField] private Toggle _Checkbox;
    [SerializeField] private Image _Visibility_Status;

    private void Awake()
    {
        _Element_List = GameObject.FindWithTag("ElementList").GetComponent<ElementList>();
    }

    private void Start()
    {
        ObjectInfo();
        VisibilityStatus();
    }

    public void ObjectRef(ObjectForManipulation _object)
    {
        _Object_Ref = _object;
    }

    private void ObjectInfo()
    {
        _Object_Name.text = _Object_Ref.gameObject.name;
    }

    public void VisibilityStatus()
    {
        if (_Object_Ref.gameObject.activeSelf)
        {
            _Visibility_Status.color = Color.blue;
        }
        else
        {
            _Visibility_Status.color = Color.gray;
        }
        
    }

    public void CheckObject()
    {
        if (_Checkbox.isOn)
        {
            _Element_List.AddElement(_Object_Ref);
        }
        else
        {
            _Element_List.RemoveElement(_Object_Ref);
        }
    }

    public void SelectObject()
    {
        _Checkbox.isOn = true;
    }

    public void ResetObject()
    {
        _Checkbox.isOn = false;
    }
}
