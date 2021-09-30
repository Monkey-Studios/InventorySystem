using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory", menuName = "Item System/Add Inventory", order = 1)]
public class Inventory : ScriptableObject
{
    //Created a public list for all item slots
    public List<ItemSlot> itemSlots = new List<ItemSlot>();
    //Created a void for adding an item to the inventory and total quantity
    public void AddItem(ItemObject itemObject, int quantity)
    {
        for(int i = 0; i < itemSlots.Count; i ++)
        {
            if(itemSlots[i].itemObject == itemObject && itemSlots[i].stackQuantity < itemObject.maxStackableQuantity)
            {
                quantity = itemSlots[i].AddToStack(quantity);
                if(quantity <= 0)
                {
                    break;
                }
            }
        }
        if(quantity>0)
        {
            itemSlots.Add(new ItemSlot(itemObject, quantity));
        }
    }

}
[System.Serializable]
public class ItemSlot
{
    public ItemObject itemObject;
    //Total item stack limit
    public int stackQuantity;
    //Inventory Item slot (itemObject and stackQuantity are local and different from the publically declared ones)
    public ItemSlot(ItemObject itemObject, int stackQuantity)
    {
        //This is stating that the public itemObject is equal to the local version
        this.itemObject = itemObject;
        //This is stating that the public stackQuantity is equal to the local version
        this.stackQuantity = stackQuantity;

    }
    public int AddToStack(int quantity)
    {
        stackQuantity += quantity;
        int remainingQuantity = stackQuantity - itemObject.maxStackableQuantity;
        //Chceking if an item quantity is at 0 or below and if so set it to 0
        if(remainingQuantity < 0)
        {
            remainingQuantity = 0;
        }
        //Takes item total away from the total quantity and then returns that quantity e.g. 5 items - 0 total quantity = 5 total items
        stackQuantity -= remainingQuantity;
        return remainingQuantity;
    }
}
