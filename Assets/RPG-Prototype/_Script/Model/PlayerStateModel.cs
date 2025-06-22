using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerStateData
{
    public float Horizontal{get; set;}
}
public class PlayerStateModel : IInitializable
{
    private PlayerStateData _playerData;
    public void Initialize()
    {
        _playerData = new PlayerStateData();

    }
    public float Horizontal
    {
        get => _playerData.Horizontal;
        set => _playerData.Horizontal = value;
    }
    private void InitialData()
    {

    }
}
