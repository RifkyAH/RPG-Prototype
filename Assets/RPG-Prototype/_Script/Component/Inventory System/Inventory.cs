using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Item> ItemCollection = new List<Item>();
    // Start is called before the first frame update
    void Start()
    {

    }

    public void AddItem(Item item)
    {
        ItemCollection.Add(item);
    }

}
