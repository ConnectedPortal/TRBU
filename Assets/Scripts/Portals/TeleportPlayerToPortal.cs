using UnityEngine;

public class TeleportPlayerToPortal : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private TeleportPlayerToPortal reciever;
    private bool playerOverlapping = false;
    private Transform traveller;

    private void Update()
    {
        if(playerOverlapping)
        {
            CheckForTeleport();
        }
    }

    private void CheckForTeleport()
    {
        if (traveller == player)
        {
            return;
        }

        Vector3 portalToPlayer = player.position - transform.position;
        float dotProduct = Vector3.Dot(transform.up, portalToPlayer);

        //if true then player has moved through the portal
        if (dotProduct < 0f)
        {
            TeleportPlayer(portalToPlayer);
        }
    }

    private void TeleportPlayer(Vector3 portalToPlayer)
    {
        reciever.TeleportingPlayerMessage(player);
        float rotationDifference = -Quaternion.Angle(transform.rotation, reciever.transform.rotation);
        rotationDifference += 180;
        player.Rotate(Vector3.up, rotationDifference);
        Vector3 positionOffset = Quaternion.Euler(0f, rotationDifference, 0f) * portalToPlayer;
        player.position = reciever.transform.position + positionOffset;

        playerOverlapping = false;
    }

    public void TeleportingPlayerMessage(Transform traveller)
    {
        this.traveller = traveller;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.root == player)
        {
            playerOverlapping = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.root == player)
        {
            playerOverlapping = false;
        }

        if (other.transform.root == traveller)
        {
            traveller = null;
        }
    }
}
