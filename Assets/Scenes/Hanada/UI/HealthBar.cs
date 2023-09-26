using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField]
    private playerHealth _health;

    [SerializeField]
    private RectTransform _barRect;

    [SerializeField]
    private RectMask2D _mask;
    private float _maxRightMask;
    private float _initialRightMask;

    private void Start()
    {
        _maxRightMask = _barRect.rect.width - _mask.padding.x - _mask.padding.z;
        _initialRightMask = _mask.padding.z;
    }


    public void SetValue(int newValue)
    {
        var targetWidth = newValue * _maxRightMask / _health.curHealth;
        var newRightMask = _maxRightMask + _initialRightMask - targetWidth;
        var padding = _mask.padding;
        padding.z = newRightMask;
        _mask.padding = padding;
    }
}
