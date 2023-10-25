using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MovingUIPanel : MonoBehaviour
{
    [SerializeField] private GameEffects _Game_Effects;

    private bool _Is_Hide = true;

    private Vector2 _Position_Right;
    private Vector2 _Position_Left;
    [SerializeField] private float _Move_Duration;
    
    private RectTransform _Rect_Transform;
    [SerializeField] private GameObject _Tab;

    private void Start()
    {
        _Rect_Transform = GetComponent<RectTransform>();
        
        _Position_Right = new Vector2(0, _Rect_Transform.anchoredPosition.y);
        _Position_Left = new Vector2(-250f, _Rect_Transform.anchoredPosition.y);
    }

    protected void HidePanel()
    {
        _Is_Hide = true;
        _Game_Effects.MovePanel(_Rect_Transform, _Position_Left, _Move_Duration);
    }

    protected void ShowPanel()
    {
        _Is_Hide = false;
        _Game_Effects.MovePanel(_Rect_Transform, _Position_Right, _Move_Duration);
    }

    public void ElementListVisibility()
    {
        if (!_Is_Hide)
        {
            HidePanel();
        }
        else
        {
            ShowPanel();
        }
    }

    protected void ShowTab()
    {
        _Tab.SetActive(true);
    }

    protected void HideTab()
    {
        _Tab.SetActive(false);
    }
}
