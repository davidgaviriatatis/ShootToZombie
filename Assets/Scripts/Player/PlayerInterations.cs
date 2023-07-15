using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInterations : MonoBehaviour
{
    public AudioSource audioSource;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("GunAmmo"))
        {
            audioSource.Play();
            GameManager.Instance.gunAmmo += other.gameObject.GetComponent<AmmoBox>().ammo;
            GameManager.Instance.grenadesAmmo += other.gameObject.GetComponent<AmmoBox>().grenade;

            other.gameObject.SetActive(false);
        }
    }
}
