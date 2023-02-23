using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PressEToActivate : MonoBehaviour
{
    [SerializeField]
    private float _range;
    [SerializeField]
    private GameObject[] _gameObjects;

    private Transform _player;

    private void Start()
    {
        _player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.eKey.wasPressedThisFrame
            && Vector3.Distance(transform.position, _player.position) < _range)
        {
            foreach (GameObject obj in _gameObjects)
            {
                obj.GetComponent<Animator>().Play("Activate");
            }
        }
    }
}
