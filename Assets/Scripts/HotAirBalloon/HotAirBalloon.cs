using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotAirBalloon : MonoBehaviour
{
    [SerializeField] private bool _isIgnited = false;
    [SerializeField] private GameObject _xrRig;
    [SerializeField] private GameObject _fire;

    private AudioSource _audioSource;
    
    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
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

        if (isIgnited)
        {
            _fire.SetActive(true);
            _audioSource.Play();
            GetComponent<Rigidbody>().AddForce(Vector3.up * 10f, ForceMode.Acceleration);
        }
        else
        {
            _audioSource.Stop();
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
