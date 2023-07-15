using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject bullet;
    public AudioClip shotSound;
    public float shotForce = 1000f, shotRate = 0.5f;

    AudioSource audioSource;
    float shotRateTime = 0;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && !GameManager.Instance.gameOver && !GameManager.Instance.winner)
        {
            if (Time.time > shotRateTime && GameManager.Instance.gunAmmo > 0)
            {
                audioSource.PlayOneShot(shotSound);

                GameObject newBullet;

                newBullet = Instantiate(bullet, spawnPoint.position, spawnPoint.rotation);

                newBullet.GetComponent<Rigidbody>().AddForce(spawnPoint.forward * shotForce);

                GameManager.Instance.gunAmmo--;

                shotRateTime = Time.time + shotRate;

                Destroy(newBullet, 3);
            }
        }
    }
}
