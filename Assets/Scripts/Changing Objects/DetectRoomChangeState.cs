using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectRoomChangeState : MonoBehaviour
{
    [SerializeField] private Transform player;
    private bool objectIsVisible = false;
    private bool playerInRoom = false;
    /// Detect if in the room
    /// Detect which state the room should be (3 room changes)
    /// Reset to beginning after 3rd state
    /// Use raycast to detect the specific parent gameobject

    private void Update()
    {
        RoomChangeDetectTest();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.root == player)
        {
            playerInRoom = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.root == player)
        {
            playerInRoom = false;
        }
    }

    private void RoomChangeDetectTest()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            objectIsVisible = true;
            Debug.Log("AAAAAAAAAAAAA");
        }
    }
}
