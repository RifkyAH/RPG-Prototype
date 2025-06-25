using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerStateData
{
    public float Horizontal { get; set; }
    public float MovementSpeed { get; set; }
}
public class PlayerStateModel : IInitializable
{
    private PlayerStateData _playerData;
    public void Initialize()
    {
        _playerData = new PlayerStateData();
        InitialData();
    }
    public float Horizontal
    {
        get => _playerData.Horizontal;
        set => _playerData.Horizontal = value;
    }
    public float MovementSpeed
    {
        get => _playerData.MovementSpeed;
        set => _playerData.MovementSpeed = value;
    }
    private void InitialData()
    {
        MovementSpeed = 5f;
    }
}
