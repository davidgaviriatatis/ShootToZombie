using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowGrenade : MonoBehaviour
{
    public float throwForce = 500f;
    public GameObject grenadePrefab;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !GameManager.Instance.gameOver && !GameManager.Instance.winner)
        {
            Throw();
        }
    }

    public void Throw()
    {
        if (GameManager.Instance.grenadesAmmo > 0)
        {
            GameObject newGrenade;
            newGrenade = Instantiate(grenadePrefab, transform.position, transform.rotation);
            newGrenade.GetComponent<Rigidbody>().AddForce(transform.forward * throwForce);
            GameManager.Instance.grenadesAmmo--;
        }
    }
}
