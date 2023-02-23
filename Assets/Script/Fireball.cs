using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(OnDeath(2));
    }

    private void OnCollisionEnter(Collision other)
    {
        EnemyHealth eh = other.gameObject.GetComponent<EnemyHealth>();

        if (eh)
        {
            eh.TakeDamage(1);
            eh.GetComponent<Rigidbody>().AddForce(Vector3.up * 10, ForceMode.Impulse);
            StartCoroutine(OnDeath(0));
        }
    }

    IEnumerator OnDeath(float time)
    {
        yield return new WaitForSeconds(time);
        ParticleSystem particles = GetComponentInChildren<ParticleSystem>();
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        

        for (int i = 0; i < 20; i++)
        {
            yield return new WaitForSeconds(0.015f);
            transform.localScale *= 0.95f;
            particles.Stop();
        }

        Destroy(gameObject);
    }
}
