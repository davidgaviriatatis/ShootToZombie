using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    void Update()
    {
        if (GameManager.Instance.gameOver)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 90);
        }
    }
}
