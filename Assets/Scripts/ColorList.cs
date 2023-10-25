using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorList : MovingUIPanel
{
    [SerializeField] private Targeting _Targeting;
    private ObjectForManipulation _Object;

    private void Awake()
    {
        GameEvents._View_Current_Object += CurrentTarget;
        GameEvents._View_All_Objects += ResetTarget;

        GameEvents._View_All_Objects += HideTab;
        GameEvents._View_All_Objects += HidePanel;

        GameEvents._View_Current_Object += ShowTab;
    }

    private void CurrentTarget()
    {
        _Object = _Targeting.Object.GetComponent<ObjectForManipulation>();
    }

    private void ResetTarget()
    {
        _Object = null;
    }
    
    public void RandomColor()
    {
        _Object?.RandomColor();
    }

    public void SetColor(ButtonForColor _button)
    {
        _Object?.SetColor(_button);
    }

    private void OnDisable()
    {
        GameEvents._View_Current_Object -= CurrentTarget;
        GameEvents._View_All_Objects -= ResetTarget;
        
        GameEvents._View_All_Objects -= HideTab;
        GameEvents._View_All_Objects -= HidePanel;

        GameEvents._View_Current_Object -= ShowTab;
    }
}
