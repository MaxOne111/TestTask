using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObjectForManipulation : MonoBehaviour
{
    private Renderer _Renderer;

    private void Awake()
    {
        _Renderer = GetComponent<Renderer>();
    }

    public void ChangeTransparency(float _value)
    {
        Color _current_Color = _Renderer.material.color;
        _Renderer.material.color = new Color(_current_Color.r, _current_Color.g, _current_Color.b, _value);
    }

    public void RandomColor()
    {
        float _r = Random.Range(0, 1f);
        float _g = Random.Range(0, 1f);
        float _b = Random.Range(0, 1f);

        _Renderer.material.color = new Color(_r, _g, _b, _Renderer.material.color.a);
    }

    public void SetColor(ButtonForColor _button)
    {
        _Renderer.material.color = new Color(_button.ObjectColor.r, _button.ObjectColor.g, _button.ObjectColor.b,
            _Renderer.material.color.a);
    }

    public void VisibilityOn()
    {
        gameObject.SetActive(true);
    }

    public void VisibilityOff()
    {
        gameObject.SetActive(false);
    }
    
}
