using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotAirBalloon : MonoBehaviour
{
    [SerializeField] private bool _isIgnited = false;
    [SerializeField] private GameObject _xrRig;
    [SerializeField] private GameObject _fire;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (_isIgnited)
        {
            
        }
        else
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }

    public void UpdateIgnitionStatus(bool isIgnited)
    {
        _isIgnited = isIgnited;
        _fire.SetActive(isIgnited);

        if (isIgnited)
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * 10f, ForceMode.Acceleration);
        }
    }

    public void ParentXRRigAfterSeconds()
    {
        Invoke(nameof(ParentXRRig), 1f);
    }

    private void ParentXRRig()
    {
        _xrRig.transform.parent = transform;
    }
}
