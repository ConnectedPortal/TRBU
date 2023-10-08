using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "KeyItem", menuName = "ScriptableObjects/Key Item Data")]
public class KeyItemData : ScriptableObject
{
    public string id;
    public string itemName;
    public string itemDescription;
    //Add a model for the item to show in inventory
}
