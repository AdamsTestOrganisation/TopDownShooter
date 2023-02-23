using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayeRShoot : MonoBehaviour
{
    [SerializeField]
    private Rigidbody _fireballPrefab;
    [SerializeField]
    private float _shootForce;

    // Update is called once per frame
    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Rigidbody fireballInstance = Instantiate(_fireballPrefab,
                transform.position + transform.forward, transform.rotation);

            fireballInstance.AddForce(transform.forward * _shootForce);
        }
    }
}
