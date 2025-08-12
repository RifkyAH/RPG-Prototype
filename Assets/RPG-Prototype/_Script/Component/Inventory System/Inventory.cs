using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Item> ItemCollection = new List<Item>();
    public ItemSlot[] itemSlot;
    // Start is called before the first frame update
    void Start()
    {

    }

    public void AddItem(Item item)
    {
        ItemCollection.Add(item);
        for (int i = 0; i < itemSlot.Length; i++)
        {
            if (itemSlot[i].isFull == false)
            {
                itemSlot[i].ShowItem(item);
                return;
            }
        }
    }

}
