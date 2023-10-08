using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUpMessenger : MonoBehaviour
{
    private InventorySystem inventorySystem;
    public KeyItemData keyItem;
    [SerializeField] private string interactionText = "Press E to Pick Up"; //Add Item Name from keyItem

    private void Start()
    {
        inventorySystem = GameObject.FindObjectOfType<InventorySystem>();
    }

    private void OnTriggerStay(Collider collider)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            OnPickupItem();
        }
    }

    private void OnPickupItem()
    {
        InventorySystem.current.Add(keyItem);
        Debug.Log(keyItem.itemName + " Added to Inventory");
        Destroy(gameObject);
    }

    //Change Interaction Text to Pick Up Message
    /*
    public string GetInteractionText()
    {
        return !doorOpened ? interactionText;
    }
    */
}
