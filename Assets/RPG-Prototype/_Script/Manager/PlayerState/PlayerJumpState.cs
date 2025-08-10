using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : PlayerBaseState
{
    public override void EnterState(PlayerStateController player)
    {
        Debug.Log(player.LastState);
        player.GetModel.JumpPressed = false;
        player.GetModel.OnGround = false;
        player.GetPlayer.rb.AddForce(Vector2.up * 10f, ForceMode2D.Impulse);
    }
    public override void FixedUpdateState(PlayerStateController player)
    {
    }
    public override void OnCollisionEnter2D(PlayerStateController player, Collision2D collision)
    {
    }
    public override void UpdateState(PlayerStateController player)
    {
        player.SwitchState(player.LastState);
    }
}
