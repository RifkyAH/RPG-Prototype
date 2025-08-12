using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    // Item Data
    private string itemName;
    // private int itemQuantity;
    private Sprite itemIcon;
    public bool isFull;
    // Slot Item
    // private TMP_Text quantityText;
    [SerializeField]private Image itemImage;
    public void ShowItem(Item item)
    {
        itemName = item.ItemName;
        itemIcon = item.ItemIcon;
        isFull = true;
        itemImage.sprite = itemIcon;
        Debug.Log(itemName);
    }
}
