using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class GameEffects : MonoBehaviour
{
    public void MovePanel(RectTransform _panel, Vector2 _end_Pos, float _duration)
    {
        _panel.DOAnchorPos(_end_Pos, _duration);
    }
}
