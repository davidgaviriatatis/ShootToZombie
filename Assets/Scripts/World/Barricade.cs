using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barricade : MonoBehaviour
{
    public AudioSource audioSourceVoltage, audioSourceExplosion;
    public GameObject electricityEffect, explosionEffect;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            if (other.gameObject.GetComponent<EnemyState>().health > 0)
            {
                other.gameObject.GetComponent<EnemyState>().health = 0;
            }

            if (GameManager.Instance.health > 0)
            {
                GameObject newElectricity = Instantiate(electricityEffect, transform.position, transform.rotation);
                audioSourceVoltage.Play();
                GameManager.Instance.health--;
                Destroy(newElectricity, 1);
            }

            if (GameManager.Instance.health <= 0)
            {
                GameObject newExplosion = Instantiate(explosionEffect, transform.position, transform.rotation);
                audioSourceExplosion.Play();
                Destroy(newExplosion, 5);
                gameObject.SetActive(false);
            }
        }
    }
}
