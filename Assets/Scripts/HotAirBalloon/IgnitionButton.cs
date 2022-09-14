using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class IgnitionButton : MonoBehaviour
{
    [SerializeField] private float _threshold = 0.1f;
    [SerializeField] private float _deadZone = 0.025f;

    private bool _isPressed;
    private Vector3 _startPosition;
    private ConfigurableJoint _joint;
    
    public UnityEvent onPressed, onReleased;

    // Start is called before the first frame update
    void Start()
    {
        _startPosition = transform.localPosition;
        _joint = GetComponent<ConfigurableJoint>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_isPressed && GetValue() + _threshold >= 1)
        {
            Pressed();
        }

        if (_isPressed && GetValue() - _threshold <= 0)
        {
            Released();
        }
    }

    private float GetValue()
    {
        var value = Vector3.Distance(_startPosition, transform.localPosition) / _joint.linearLimit.limit;
        if (Math.Abs(value) < _deadZone)
        {
            value = 0;
        }

        return Mathf.Clamp(value, -1f, 1f);
    }
    
    private void Pressed()
    {
        _isPressed = true;
        onPressed.Invoke();
        Debug.Log("Pressed");
    }

    private void Released()
    {
        _isPressed = false;
        onReleased.Invoke();
        Debug.Log("Released");
    }
}
