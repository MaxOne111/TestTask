using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoom : MonoBehaviour
{
    [SerializeField] Camera _Camera;

    private float _Zoom;

    [SerializeField] private float _Scroll_Speed = 50f;

    [SerializeField] private float _Max_Zoom = 60f;
    [SerializeField] private float _Min_Zoom = 15f;

    private void Awake()
    {
        GameEvents._View_All_Objects += StartPosition;
    }
    
    private void LateUpdate()
    {
        ZoomFunction();
    }

    private void StartPosition()
    {
        _Camera.fieldOfView = 60;
    }
    

    private void ZoomFunction()
    {
        _Zoom = _Camera.fieldOfView;
        
        _Zoom -= Input.GetAxis("Mouse ScrollWheel") * _Scroll_Speed;
        _Zoom = Mathf.Clamp(_Zoom, _Min_Zoom, _Max_Zoom);
        
        _Camera.fieldOfView = _Zoom;

    }

   
}
