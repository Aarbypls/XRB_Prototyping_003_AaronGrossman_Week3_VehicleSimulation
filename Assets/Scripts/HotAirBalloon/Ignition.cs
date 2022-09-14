using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ignition : MonoBehaviour
{
    [SerializeField] private HotAirBalloon _hotAirBalloon;
    [SerializeField] private bool _ignitionStatusSet;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer != 7 ) // Panel
        {
            _hotAirBalloon.UpdateIgnitionStatus(_ignitionStatusSet);
        }
    }
}
