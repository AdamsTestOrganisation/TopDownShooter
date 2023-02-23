using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private float _followSpeed;
    private Vector3 _offset;
    [SerializeField]
    private Transform _target;

    // Start is called before the first frame update
    void Start()
    {
        _offset = transform.position - _target.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, 
            _target.position + _offset, _followSpeed * Time.deltaTime);
    }
}
