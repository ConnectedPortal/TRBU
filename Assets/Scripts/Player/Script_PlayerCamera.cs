using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_PlayerCamera : MonoBehaviour
{
    [Header("Cutscenes")]
    private GameManager gameManager;

    [Header("Values")]
    [SerializeField] private float mouseSensitivity;
    [SerializeField] private Transform playerBody;
    private float xRotation;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    void Update()
    {
        if (!gameManager.focusOnObject) CameraFollowCursor();
        else CameraLookAtTarget();
    }

    private void CameraFollowCursor()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }

    private void CameraLookAtTarget()
    {
        Quaternion targetRotation = Quaternion.LookRotation(gameManager.objectTarget.transform.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 5f * Time.deltaTime);
    }
}
