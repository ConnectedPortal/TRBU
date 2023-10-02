using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_FakeRoomFlip : MonoBehaviour
{
    [SerializeField] private Script_FakeRoomFlip otherRoom;
    [SerializeField] private Script_Test fallingObject;
    [SerializeField] private Transform player;
    //[SerializeField] private bool playerInRoom = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.root == player)
        {
            //playerInRoom = true;
            otherRoom.PlayerNotInRoom();
            MakeObjectKinematicMessage();
        }
    }

    public void PlayerNotInRoom()
    {
        //playerInRoom = false;
    }

    void MakeObjectKinematicMessage()
    {
        fallingObject.isActive = true;
    }
}
