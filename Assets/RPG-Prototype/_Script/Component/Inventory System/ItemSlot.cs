using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    // Item Data
    public Item DataItem;
    public int itemQuantity;
    public bool hasItem;
    // Slot Item
    public GameObject selectedShader, itemActionPanel;
    public bool isSelected = false;
    Inventory inventory;
    [SerializeField] private Image itemImage;
    // Item Slot Description
    [SerializeField] private Image itemDescImage;
    [SerializeField] private TMP_Text itemDescName;
    [SerializeField] private TMP_Text itemDescText;
    [SerializeField] public TMP_Text itemQuantityText;
    void Start()
    {
        inventory = FindAnyObjectByType<Inventory>();
    }
    public void ShowItem(Item item)
    {
        DataItem = item;
        if (DataItem.isStackable)
        {
            itemQuantity += DataItem.ItemQuantity;
            itemQuantityText.text = itemQuantity.ToString();
        }
        hasItem = true;
        itemImage.sprite = DataItem.ItemIcon;
    }
    public void ShowDescItem()
    {
        itemDescName.text = DataItem.ItemName;
        itemDescText.text = DataItem.ItemDescription;
        itemDescImage.sprite = DataItem.ItemIcon;
    }
    public void SelectSlot()
    {
        inventory.DeselectAllSlots();
        ShowDescItem();
        selectedShader.SetActive(true);
        itemActionPanel.SetActive(true);
        isSelected = true;
        inventory.currentItemSlot = this;
    }
    public void UseItem(PlayerStatsModel statsModel)
    {
        if (DataItem.ItemType == ItemType.Consumable)
        {
            DataItem.itemEffect.ApplyEffect(statsModel);
            inventory.DeleteItem();
        }
    }
 
    public void EmptySlot()
    {
        itemImage.sprite = null;
        itemDescName.text = "";
        itemDescText.text = "";
        itemDescImage.sprite = null;
        hasItem = false;
        DataItem = null;
        itemQuantityText.text = "";
    }
}
