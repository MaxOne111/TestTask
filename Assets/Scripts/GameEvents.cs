using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameEvents
{
    public static Action _View_Current_Object;
    public static Action _View_All_Objects;

    public static void ViewCurrentObject()
    {
        _View_Current_Object?.Invoke();
    }

    public static void ViewAllObjects()
    {
        _View_All_Objects?.Invoke();
    }
    
}
