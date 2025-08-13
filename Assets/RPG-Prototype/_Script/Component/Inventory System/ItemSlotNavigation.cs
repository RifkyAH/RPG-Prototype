using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using Zenject;

public class ItemSlotNavigation : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [Inject] private GameControlBinder Input;
    void Awake()
    {
        mainCamera = FindAnyObjectByType<Camera>();
        Input.OnInventoryNavAsObservable().Subscribe(_ => InventoryNav()).AddTo(this);
    }
    void InventoryNav()
    {
        PointerEventData pointerData = new PointerEventData(EventSystem.current)
        {
            position = Mouse.current.position.ReadValue()
        };
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointerData, results);

        foreach (var hit in results)
        {
            ItemSlot slot = hit.gameObject.GetComponent<ItemSlot>();
            if (slot != null)
            {
                slot.SelectSlot();
                break;
            }
        }
    }
}
