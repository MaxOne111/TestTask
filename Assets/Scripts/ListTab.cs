using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ListTab : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private MovingUIPanel _List;
    
    public void OnPointerDown(PointerEventData eventData)
    {
        _List.ElementListVisibility();
    }
    
    
}
