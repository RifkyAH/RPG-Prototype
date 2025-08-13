using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Item> ItemCollection = new List<Item>();
    public ItemSlot[] itemSlot;

    void Start()
    {

    }

    public void AddItem(Item item)
    {
        ItemCollection.Add(item);
        for (int i = 0; i < itemSlot.Length; i++)
        {
            // Stacking item    
            if (item.isStackable)
            {
                if (itemSlot[i].hasItem && item.ItemName == itemSlot[i].itemName && itemSlot[i].itemQuantity <= item.MaxItem)
                {
                    itemSlot[i].ShowItem(item, item.ItemQuantity);
                    return;
                }
            }
            if (!itemSlot[i].hasItem)
            {
                itemSlot[i].ShowItem(item, item.ItemQuantity);
                return;
            }
        }
    }
    public void DeselectAllSlots()
    {
        for (int i = 0; i < itemSlot.Length; i++)
        {
            itemSlot[i].selectedShader.SetActive(false);
            itemSlot[i].isSelected = false;
        }
    }
}
