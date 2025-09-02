using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class GameControlBinder : MonoBehaviour
{
    private UnityEvent _Inventory;
    private UnityEvent _InventoryNav;
    public IObservable<Unit> OnInventoryOpenAsObservable()
    {
        return _Inventory.AsObservable();
    }
    public IObservable<Unit> OnInventoryNavAsObservable()
    {
        return _InventoryNav.AsObservable();
    }
    void Awake()
    {
        _Inventory = new UnityEvent();
        _InventoryNav = new UnityEvent();
    }
    private void OnInventory(InputValue value)
    {
        _Inventory?.Invoke();
    }
    private void OnClick(InputValue value)
    {
        _InventoryNav?.Invoke();
    }
}
