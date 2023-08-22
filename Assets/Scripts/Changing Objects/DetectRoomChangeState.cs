using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectRoomChangeState : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private GameObject appearingObject; //TEST, SPLIT TO ANOTHER SCRIPT AFTER
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
        /*
        if (Input.GetKeyDown(KeyCode.E))
        {
            objectIsVisible = true;
            Debug.Log("AAAAAAAAAAAAA");
        }
        */

        if (playerInRoom)
        {
            /*
            Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            Debug.DrawRay(ray.origin, ray.direction * 10);
            */

            RaycastHit hitData;

            if (Physics.Raycast(Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0)), out hitData, Mathf.Infinity))
            {
                Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.TransformDirection(Vector3.forward) * hitData.distance, Color.yellow);
                
                if(hitData.transform.CompareTag("Trigger"))
                {
                    appearingObject.SetActive(true);
                    //Debug.Log("Did Hit");
                }
            }
        }
    }
}
