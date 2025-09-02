using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Inventory : MonoBehaviour
{
    [Inject] PlayerStatsModel statsModel;
    public List<Item> ItemCollection = new List<Item>();
    public ItemSlot[] itemSlot;
    public ItemSlot currentItemSlot;
    [SerializeField] private GameObject dropSpawn;

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
                if (itemSlot[i].hasItem && item.ItemName == itemSlot[i].DataItem.ItemName && itemSlot[i].DataItem.ItemQuantity <= item.MaxItem)
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
    public void DeleteItem()
    {
        if (currentItemSlot.DataItem.isStackable)
        {
            currentItemSlot.itemQuantity -= 1;
            currentItemSlot.itemQuantityText.text = currentItemSlot.itemQuantity.ToString();
            if (currentItemSlot.itemQuantity <= 0)
            {
                currentItemSlot.EmptySlot();
            }
        }
        else
        {
            currentItemSlot.EmptySlot();
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
    void HideActionUI()
    {
        currentItemSlot.itemActionPanel.SetActive(false);
        currentItemSlot.selectedShader.SetActive(false);
        currentItemSlot.isSelected = false;
    }
    #region ActionPanel
    public void UseItem()
    {
        Debug.Log("Healing for everyone");
        currentItemSlot.UseItem(statsModel);
        HideActionUI();
    }
    public void DropItem()
    {
        GameObject droppedItem = Instantiate(currentItemSlot.DataItem.ItemDropPrefab, dropSpawn.transform.position, dropSpawn.transform.rotation);
        ItemsPickup Dataitem = droppedItem.GetComponent<ItemsPickup>();
        Dataitem.SetItem(currentItemSlot.DataItem);
        DeleteItem();
        HideActionUI();
    }
    public void Cancle()
    {
        DeselectAllSlots();
        HideActionUI();
    }
    #endregion
}
