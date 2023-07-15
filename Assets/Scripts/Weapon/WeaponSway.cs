using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSway : MonoBehaviour
{
    public float swayAmount = 8;

    Quaternion startRotation, xAngle, yAngle, targetRotation;
    float mouseX, mouseY;

    void Start()
    {
        startRotation = transform.localRotation;
    }

    void Update()
    {
        if (!GameManager.Instance.gameOver && !GameManager.Instance.winner)
        {
            Sway();
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    private void Sway()
    {
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");

        xAngle = Quaternion.AngleAxis(mouseX * -1.25f, Vector3.up);
        yAngle = Quaternion.AngleAxis(mouseY * 1.25f, Vector3.left);

        targetRotation = startRotation * xAngle * yAngle;

        transform.localRotation = Quaternion.Lerp(transform.localRotation, targetRotation, Time.deltaTime * swayAmount);
    }
}
