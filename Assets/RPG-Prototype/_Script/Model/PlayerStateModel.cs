using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerStateData
{
    public float Horizontal { get; set; }
    public float MovementSpeed { get; set; }
    public bool JumpPressed { get; set; }
    public bool OnGround { get; set; }
    public bool IsFacingRight { get; set; }
    public bool MeleeAttackPressed { get; set; }
    public bool BowAttackPressed { get; set; }
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
    public bool JumpPressed
    {
        get => _playerData.JumpPressed;
        set => _playerData.JumpPressed = value;
    }
    public bool OnGround
    {
        get => _playerData.OnGround;
        set => _playerData.OnGround = value;
    }
    public bool IsFacingRight
    {
        get => _playerData.IsFacingRight;
        set => _playerData.IsFacingRight = value;
    }
    public bool MeleeAttackPressed
    {
        get => _playerData.MeleeAttackPressed;
        set => _playerData.MeleeAttackPressed = value;
    }
    public bool BowAttackPressed
    {
        get => _playerData.BowAttackPressed;
        set => _playerData.BowAttackPressed = value;
    }
    private void InitialData()
    {
        MovementSpeed = 5f;
        JumpPressed = false;
        OnGround = false;
        IsFacingRight = true;
        MeleeAttackPressed = false;
        BowAttackPressed = false;
    }
}
