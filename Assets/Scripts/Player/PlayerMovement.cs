using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController characterController;
    public float speed = 10f;
    public Transform groundCheck;
    public LayerMask groundMask;

    Vector3 velocity;
    float x, z, gravity = -9.81f, sphereRadius = 0.3f;
    bool isGrounded;

    void Start()
    {
        
    }

    void Update()
    {
        if (!GameManager.Instance.gameOver && !GameManager.Instance.winner)
        {
            isGrounded = Physics.CheckSphere(groundCheck.position, sphereRadius, groundMask);

            if (isGrounded && velocity.y < 0)
            {
                velocity.y = -2f;
            }

            x = Input.GetAxis("Horizontal");
            z = Input.GetAxis("Vertical");

            Vector3 move = transform.right * x + transform.forward * z;

            characterController.Move(move * speed * Time.deltaTime);

            velocity.y += gravity * Time.deltaTime;

            characterController.Move(velocity * Time.deltaTime);
        }
    }
}
