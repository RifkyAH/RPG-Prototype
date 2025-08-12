using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItemsPickup : MonoBehaviour
{
    [SerializeField] private Item m_Item;
    private SpriteRenderer m_Sprite;
    private Inventory m_Inventory;
    void Awake()
    {
        // Mengambil Sprite dari ScriptableObject
        m_Sprite = GetComponent<SpriteRenderer>();
        m_Sprite.sprite = m_Item.ItemIcon;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            m_Inventory = other.GetComponent<Inventory>();
            PickUp(m_Inventory);
        }
    }
    void PickUp(Inventory inventory)
    {
        inventory.AddItem(m_Item);
        Destroy(gameObject);
    }
}
