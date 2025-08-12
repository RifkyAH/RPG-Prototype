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
    private string itemName;
    // private int itemQuantity;
    private Sprite itemIcon;
    public bool isFull;
    // Slot Item
    // private TMP_Text quantityText;
    public GameObject selectedShader;
    public bool isSelected;
    Inventory inventory;
    [SerializeField] private Image itemImage;
    void Start()
    {
        inventory = FindAnyObjectByType<Inventory>();
    }
    public void ShowItem(Item item)
    {
        itemName = item.ItemName;
        itemIcon = item.ItemIcon;
        isFull = true;
        itemImage.sprite = itemIcon;
        Debug.Log(itemName);
    }
    public void SelectSlot()
    {
        inventory.DeselectAllSlots();
        selectedShader.SetActive(true);
        isSelected = true;
    }
}
