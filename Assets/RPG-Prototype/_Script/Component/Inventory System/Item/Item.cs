using UnityEngine;

public enum ItemType
{
    All,
    Armor,
    Weapon,
    Consumable,
    Material
}
[CreateAssetMenu(fileName = "Items", menuName = "ScriptableObjects/Items")]
public class Item : ScriptableObject
{
    public int ItemId, MaxItem, ItemQuantity;
    public string ItemName;
    public Sprite ItemIcon;
    public string ItemDescription;
    public ItemType ItemType;
    public bool isStackable;
    public ItemEffect itemEffect;
    public GameObject ItemDropPrefab;
}
