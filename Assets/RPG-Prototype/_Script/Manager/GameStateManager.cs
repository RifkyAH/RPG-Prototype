using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using Zenject;

public class GameStateManager : MonoBehaviour
{
    public enum GameState
    {
        Playing,
        Pause,
        Inventory
    }
    [Inject] GameControlBinder _input;
    public ReactiveProperty<GameState> currentState = new ReactiveProperty<GameState>(GameState.Playing);
    public GameState lastState;
    void Awake()
    {
        _input.OnInventoryOpenAsObservable().Subscribe(_ => OpenInventory()).AddTo(this);
    }

    private void OpenInventory()
    {
        if (currentState.Value == GameState.Inventory)
        {
            Debug.Log("Playing");
            ChangeState(GameState.Playing);
        }
        else if (currentState.Value == GameState.Playing)
        {
            Debug.Log("Inventory");
            ChangeState(GameState.Inventory);
        }
    }
    public void ChangeState(GameState state)
    {
        if (currentState.Value != state)
        {
            lastState = currentState.Value;
            currentState.Value = state;
        }
    }
}
