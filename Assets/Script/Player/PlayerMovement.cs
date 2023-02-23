using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float _speed;
    [SerializeField]
    private float _jumpHeight;

    private Vector2 _movement;
    private bool _canJump;
    private Rigidbody _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    public void OnJump()
    {
        _canJump = true;
    }

    


    // Update is called once per frame
    void Update()
    {
        //grab mouse
        Mouse mouse = Mouse.current;
        //save variable for later
        RaycastHit hit;
        //Use mouse position with camera to create a Ray
        Ray ray = Camera.main.ScreenPointToRay(mouse.position.ReadValue());

        //Raycast
        if (Physics.Raycast(ray, out hit))
        {
            //Look at point
            Vector3 point = new Vector3(hit.point.x, transform.position.y, hit.point.z);
            transform.forward = point - transform.position;
        }


    }

    public void OnMove(InputValue value)
    {
        _movement = value.Get<Vector2>();
    }

    private bool IsGrounded()
    {
        Vector3 origin = transform.position;
        Vector3 direction = Vector3.down;
        float distance = 1.01f;

        bool onGround = Physics.Raycast(origin, direction, distance);

        return onGround;
       
    }

    private void FixedUpdate()
    {
        if (_canJump && IsGrounded())
        {
            _rb.AddForce(Vector3.up * _jumpHeight, ForceMode.Impulse);
        }
        _canJump = false;

        _rb.position += new Vector3(_movement.x, 0, _movement.y)
            * _speed * Time.deltaTime;
    }
}
