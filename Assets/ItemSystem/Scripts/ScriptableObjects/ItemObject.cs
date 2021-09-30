using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item Object", menuName = "Item System/Add Item", order = 2)]
public class ItemObject : ScriptableObject
{
    //Used to represent the item within the 3d space of the gameworld and how the player will see it outside the inventory
    public GameObject itemPrefab;
    //Used to represent the item within the inventory system
    public Sprite icon;
    //Items inventory name
    public string itemName;
    [TextArea(4, 16)]
    //Description of the item within the system
    public string description;
    //The weight of the item
    public float weight = 0;
    //Max stackable total of the item within one inventory slot, this may be used more so on food items or things like arrows
    public int maxStackableQuantity = 1;
    //If this variable is true item will be used on pick up if not sent to inventory storage 
    public bool usedOnPickup = true;
    //If true the item will be destroyed or the item quantity will be reduced by 1 if it is a stacked item
    public bool consumable = true;
}
