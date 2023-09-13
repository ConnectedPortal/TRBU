using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_PlayerMovement : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private CharacterController controller;

    [Header("Movement Values")]
    [SerializeField] private float playerSpeed = 15f;
    [SerializeField] private float gravity = -9.81f;
    private Vector3 playerVelocity;

    [Header("Ground Check Values")]
    [SerializeField] Transform groundCheck;
    [SerializeField] private float groundDistance = 0.4f;
    [SerializeField] LayerMask groundMask;
    private bool isGrounded;


    void Update()
    {
        GroundCheck();
        Movement();
    }

    private void Movement()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputZ = Input.GetAxis("Vertical");

        Vector3 move = transform.right * inputX + transform.forward * inputZ;
        controller.Move(move * playerSpeed * Time.deltaTime);
        playerVelocity.y += gravity * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }

    private void GroundCheck()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded)
        {
            playerVelocity.y = 0f;
        }
    }
}
