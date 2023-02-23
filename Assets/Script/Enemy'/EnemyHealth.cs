using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    private float _health;
    [SerializeField]
    private GameObject _explosionParticle;

    public void TakeDamage(float damage)
    {
        if (_health > 0)
        {
            _health -= damage;
        }

        if (_health <= 0)
        {
            StartCoroutine(OnDeath());
        }
    }

    private IEnumerator OnDeath()
    {
        GetComponent<Rigidbody>().AddForce(Vector3.up * 20, ForceMode.Impulse);
        GetComponent<EnemyMovement>().enabled = false;

        yield return new WaitForSeconds(0.5f);

        for (int i = 0; i < 10; i++)
        {
            yield return new WaitForSeconds(0.01f);
            transform.localScale *= 1.05f;
        }

        GameObject obj = Instantiate(_explosionParticle, transform.position, Quaternion.identity);
        Destroy(obj, 0.3f);
        
        Destroy(gameObject);
    }

   

}
