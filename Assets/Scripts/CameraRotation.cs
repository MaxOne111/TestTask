using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    private CompositeDisposable _Disposable = new CompositeDisposable();
    
    [SerializeField] private Camera _Camera;
    
    public Transform Target { get; private set; }
    
    private Vector3 _Prev_Position;

    public void StartRotate()
    {
        _Disposable.Clear();
        
        Observable.EveryUpdate().Subscribe(_ =>
        {
            if (Input.GetMouseButtonDown(1))
            {
                _Prev_Position = _Camera.ScreenToViewportPoint(Input.mousePosition);
            }
            if (Input.GetMouseButton(1))
            {
                Rotate();
            }
        }).AddTo(_Disposable);
    }

    public void FinishRotate()
    {
        _Disposable.Clear();
    }

    public void CurrentTarget(Transform _target)
    {
        Target = _target;
    }

    private void Rotate()
    {
        Vector3 _direction = _Prev_Position - _Camera.ScreenToViewportPoint(Input.mousePosition);

        _Camera.transform.position = Target.position;
        
        _Camera.transform.Rotate(Vector3.right, _direction.y * 180);
        _Camera.transform.Rotate(Vector3.up, -_direction.x * 180, Space.World);
        _Camera.transform.Translate(new Vector3(0,0,-4));
        
        _Prev_Position = _Camera.ScreenToViewportPoint(Input.mousePosition);
        
    }

    private void OnDisable()
    {
        _Disposable.Clear();
    }
}
