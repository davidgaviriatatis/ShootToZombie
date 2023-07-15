using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    public float delay = 2, radius = 5;
    public GameObject explosionEffect;
    public AudioClip explosionSound;

    AudioSource audioSource;
    float countDown;
    bool exploded = false;

    void Start()
    {
        countDown = delay;
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        countDown -= Time.deltaTime;

        if (countDown <= 0 && exploded ==  false)
        {
            explode();
            exploded = true;
        }
    }

    private void explode()
    {
        GameObject newExplosion = Instantiate(explosionEffect, transform.position, transform.rotation);

        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

        foreach (var rangeObject in colliders)
        {
            if (rangeObject.CompareTag("Enemy"))
            {
                if (!rangeObject.gameObject.GetComponent<EnemyState>().isDead)
                {
                    rangeObject.gameObject.GetComponent<EnemyState>().health = 0;
                }
            }
        }

        audioSource.PlayOneShot(explosionSound);

        gameObject.GetComponent<SphereCollider>().enabled = false;
        gameObject.GetComponent<MeshRenderer>().enabled = false;

        Destroy(newExplosion, 1);
        Destroy(gameObject, delay * 2);
    }
}
