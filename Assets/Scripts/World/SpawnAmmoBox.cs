using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAmmoBox : MonoBehaviour
{
    public List<GameObject> ammoBoxes = new List<GameObject>();
    public float timeSpawn = 20f;

    int ammoBoxesNumber;
    float countDown;

    void Start()
    {
        ammoBoxesNumber = ammoBoxes.Count;
        countDown = timeSpawn;
    }

    // Update is called once per frame
    void Update()
    {
        countDown -= Time.deltaTime;

        if (countDown <= 0)
        {
            Spawn();
        }
    }

    private void Spawn()
    {
        if (ammoBoxesNumber > 0)
        {
            ammoBoxes[ammoBoxesNumber - 1].SetActive(true);
            ammoBoxesNumber--;
        }

        countDown = timeSpawn;
    }
}
