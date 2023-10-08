using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    private Dictionary<KeyItemData, InventoryItem> itemDictionary;
    public List<InventoryItem> inventory { get; private set; }
    public static InventorySystem current;

    private void Awake()
    {
        inventory = new List<InventoryItem>();
        itemDictionary = new Dictionary<KeyItemData, InventoryItem>();
        current = this;
    }

    public void Add(KeyItemData itemData)
    {
        if (itemDictionary.TryGetValue(itemData, out InventoryItem value))
        {
            value.AddToStack();
            Debug.Log("Duplicate Item Added: " + itemData.itemName);
        }
        else
        {
            InventoryItem newItem = new InventoryItem(itemData);
            inventory.Add(newItem);
            itemDictionary.Add(itemData, newItem);
            Debug.Log("Unique Item Added: " + itemData.itemName);
        }
    }

    public void Remove(KeyItemData itemData)
    {
        if (itemDictionary.TryGetValue(itemData, out InventoryItem value))
        {
            value.RemoveFromStack();
            Debug.Log("Duplicate Item Removed: " + itemData.itemName);

            if (value.stackSize == 0)
            {
                inventory.Remove(value);
                itemDictionary.Remove(itemData);
                Debug.Log("Item Fully Removed: " + itemData.itemName);
            }
        }
    }

    public InventoryItem Get(KeyItemData itemData)
    {
        if (itemDictionary.TryGetValue(itemData, out InventoryItem value))
        {
            return value;
        }
        return null;
    }
}
