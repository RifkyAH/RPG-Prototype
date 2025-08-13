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
    public string itemName,itemDescription;
    public int itemQuantity;
    private Sprite itemIcon;
    public bool hasItem;
    // Slot Item
    // private TMP_Text quantityText;
    public GameObject selectedShader;
    public bool isSelected = false;
    Inventory inventory;
    [SerializeField] private Image itemImage;
    // Item Slot Description
    [SerializeField] private Image itemDescImage;
    [SerializeField] private TMP_Text itemDescName;
    [SerializeField] private TMP_Text itemDescText;
    [SerializeField] private TMP_Text itemQuantityText;
    void Start()
    {
        inventory = FindAnyObjectByType<Inventory>();
    }
    public void ShowItem(Item item,int quantity)
    {
        itemName = item.ItemName;
        itemIcon = item.ItemIcon;
        itemQuantity += quantity;
        itemQuantityText.text = itemQuantity.ToString();
        itemDescription = item.ItemDescription;
        hasItem = true;
        itemImage.sprite = itemIcon;
    }
    public void ShowDescItem()
    {
        itemDescName.text = itemName;
        itemDescText.text = itemDescription;
        itemDescImage.sprite = itemIcon;
    }
    public void SelectSlot()
    {
        inventory.DeselectAllSlots();
        ShowDescItem();
        selectedShader.SetActive(true);
        isSelected = true;
    }
}
