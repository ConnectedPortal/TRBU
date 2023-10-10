using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private CharacterController controller;
    [SerializeField] private GameManager gameManager;
    private PlayerControls playerControls;

    [Header("Movement Values")]
    [SerializeField] private float playerSpeed = 15f;
    [SerializeField] private float gravity = -9.81f;
    private Vector3 playerVelocity;

    [Header("Ground Check Values")]
    [SerializeField] Transform groundCheck;
    [SerializeField] private float groundDistance = 0.4f;
    [SerializeField] LayerMask groundMask;
    private bool isGrounded;

    private void Awake()
    {
        playerControls = new PlayerControls();
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

    void Update()
    {
        GroundCheck();

        if (!gameManager.isInCutscene)
        {
            Movement();
        }
    }

    private void Movement()
    {
        /*
        float inputX = Input.GetAxis("Horizontal");
        float inputZ = Input.GetAxis("Vertical");
        */
        Vector2 moveInput = playerControls.Gameplay.Movement.ReadValue<Vector2>();

        //Vector3 move = transform.right * inputX + transform.forward * inputZ;
        Vector3 movement = transform.right * moveInput.x + transform.forward * moveInput.y;

        controller.Move(movement * playerSpeed * Time.deltaTime);
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
