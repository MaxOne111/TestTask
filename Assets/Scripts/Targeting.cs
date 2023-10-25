using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class Targeting : MonoBehaviour
{
    private CompositeDisposable _Disposable = new CompositeDisposable();

    [SerializeField] private CameraRotation _Camera_Rotation;
    [SerializeField] private Zoom _Zoom;

    [SerializeField] private Camera _Main_Camera;

    [SerializeField] private float _Move_Speed = 3;
    
    [SerializeField] private Transform _Start_Position;
    
    [SerializeField] private Vector3 _View_Position;
    [SerializeField] private Vector3 _View_Rotation;

    
    public Transform Object { get; private set; }

    private Ray _Ray;
    private RaycastHit _Hit;
    private float _Distance = 1000;
    

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CreateRay();
        }
    }

    private void CreateRay()
    {
        Vector3 _mouse_Pos = Input.mousePosition;

        _Ray = _Main_Camera.ScreenPointToRay(_mouse_Pos);

        if (Physics.Raycast(_Ray, out _Hit, _Distance))
        {
            if (_Hit.collider.TryGetComponent(out ObjectForManipulation _object))
            {
                ChooseObject(_object.transform);
                _Camera_Rotation.CurrentTarget(_object.transform);
            }
        }
    }

    private void ChooseObject(Transform _object)
    {
        Object = _object;
        _Disposable.Clear();
        _Distance = 0;
        
        GameEvents.ViewCurrentObject();
        
        _Camera_Rotation.FinishRotate();

        _Zoom.enabled = true;

        _Main_Camera.transform.position = _Start_Position.position;
        _Main_Camera.transform.eulerAngles = _Start_Position.eulerAngles;

        Observable.EveryUpdate().Subscribe(l =>
        {
            ViewCurrentObject();
            
        }).AddTo(_Disposable);
    }

    private void ViewCurrentObject()
    {
        Vector3 _view_Pos = new Vector3(Object.position.x + _View_Position.x, Object.position.y + _View_Position.y,
            Object.position.z + _View_Position.z);
        
        _Main_Camera.transform.eulerAngles = Vector3.Lerp(_Main_Camera.transform.eulerAngles, _View_Rotation, _Move_Speed * Time.deltaTime);
        
        if (_Main_Camera.transform.position == _view_Pos)
        {
            _Camera_Rotation.StartRotate();
            
            _Disposable.Clear();
            return;
        }
        
        _Main_Camera.transform.position = Vector3.Lerp(_Main_Camera.transform.position, _view_Pos, _Move_Speed * Time.deltaTime);
    }

    public void ResetObject()
    {
        Object = null;
        _Disposable.Clear();
        _Distance = 1000;
        
        GameEvents.ViewAllObjects();

        _Camera_Rotation.FinishRotate();

        _Zoom.enabled = false;
        
        _Main_Camera.transform.eulerAngles = _Start_Position.eulerAngles;

        Observable.EveryUpdate().Subscribe(l =>
        {
            ViewAllObjects();
            
        }).AddTo(_Disposable);
    }
    
    private void ViewAllObjects()
    {
        _Main_Camera.transform.eulerAngles = Vector3.Lerp(_Main_Camera.transform.eulerAngles, _Start_Position.eulerAngles, _Move_Speed * Time.deltaTime);
        
        if (_Main_Camera.transform.position == _Start_Position.position)
        {
            _Disposable.Clear();
            return;
        }
        
        _Main_Camera.transform.position = Vector3.Lerp(_Main_Camera.transform.position, _Start_Position.position, _Move_Speed * Time.deltaTime);
    }
    
    private void OnDisable()
    {
        _Disposable.Clear();
    }

}
