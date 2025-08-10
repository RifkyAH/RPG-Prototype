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
    public IObservable<Unit> OnInventoryOpenAsObservable()
    {
        return _Inventory.AsObservable();
    }
    void Awake()
    {
        _Inventory = new UnityEvent();
    }
    private void OnInventory(InputValue value)
    {
        _Inventory?.Invoke();
    }
}
