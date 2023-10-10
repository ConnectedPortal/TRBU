using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUpMessenger : MonoBehaviour
{
    [Header("Input System")]
    private PlayerControls playerControls;

    [Header("Item References")]
    private InventorySystem inventorySystem;
    public KeyItemData keyItem;
    [SerializeField] private string interactionText = "Press E to Pick Up"; //Add Item Name from keyItem

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

    private void Start()
    {
        inventorySystem = GameObject.FindObjectOfType<InventorySystem>();
    }

    private void OnTriggerStay(Collider collider)
    {
        if (playerControls.Gameplay.Interaction.triggered)
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
