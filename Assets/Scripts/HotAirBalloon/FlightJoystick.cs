using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlightJoystick : MonoBehaviour
{
    public Transform topOfJoystick;

    [SerializeField] private GameObject _hotAirBalloon;
    
    [SerializeField] private float _forwardBackwardTilt = 0f;
    [SerializeField] private float _sideToSideTilt = 0f;

    [SerializeField] private float _movementSpeed = 3f;
    [SerializeField] private float _rotationSpeed = 10.0f;

    private bool _moving = false;
    
    void FixedUpdate()
    {
        _forwardBackwardTilt = topOfJoystick.rotation.eulerAngles.x;
        _sideToSideTilt = topOfJoystick.rotation.eulerAngles.z;
        
        if (_forwardBackwardTilt < 310 && _forwardBackwardTilt > 290)
        {
            _forwardBackwardTilt = Math.Abs(_forwardBackwardTilt - 360);

            if (!_moving)
            {
                _hotAirBalloon.GetComponent<Rigidbody>().AddForce(_hotAirBalloon.transform.right * _movementSpeed, ForceMode.VelocityChange);
                _moving = true;
            }
        }
        else if ((_forwardBackwardTilt > 0 && _forwardBackwardTilt < 25) || (_forwardBackwardTilt > 340))
        {
            _hotAirBalloon.GetComponent<Rigidbody>().AddForce(_hotAirBalloon.transform.right * -_movementSpeed, ForceMode.VelocityChange);
        }
        else if (_sideToSideTilt < 345 && _sideToSideTilt > 310)
        {
            _sideToSideTilt = Math.Abs(_sideToSideTilt - 360);
            _hotAirBalloon.transform.Rotate(new Vector3(0, 1, 0) * Time.deltaTime * _rotationSpeed);
        }
        else if (_sideToSideTilt > 15 && _sideToSideTilt < 50)
        {
            _hotAirBalloon.transform.Rotate(new Vector3(0, -1, 0) * Time.deltaTime * _rotationSpeed);
        }
        else
        {
            _moving = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("PlayerHand"))
        {
            transform.LookAt(other.transform.position, transform.up);
        }
    }
}
