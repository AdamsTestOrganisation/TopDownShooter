using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    private float _speed;
    [SerializeField]
    private float _aggroRange;
    private Transform _player;

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindWithTag("Player").transform;
    }

    private bool CanSeePlayer()
    {
        Vector3 origin = transform.position;
        Vector3 direction = (_player.position - transform.position).normalized;

        RaycastHit hit;

        if (Physics.Raycast(origin, direction, out hit))
        {
            if (hit.transform.tag == "Player")
            {
                return true;
            }
        }
        return false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, _player.position) > _aggroRange
            || !CanSeePlayer())
            return;

        //Grab target position with adjusted height
        Vector3 targetPos = new Vector3(_player.position.x, 
            transform.position.y, _player.position.z);

        //Move towards player
        transform.position = Vector3.MoveTowards(transform.position,
            _player.position, _speed * Time.deltaTime);
    }
}
