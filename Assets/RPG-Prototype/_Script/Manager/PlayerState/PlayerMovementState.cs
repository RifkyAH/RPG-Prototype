using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementState : PlayerBaseState
{
    public override void EnterState(PlayerStateController player)
    {
    
    }
    public override void FixedUpdateState(PlayerStateController player)
    {
        float Horizontal = player.GetModel.Horizontal;
        Vector2 velocity = player.GetPlayer.rb.velocity;
        velocity.x = Horizontal * player.GetModel.MovementSpeed;
        player.GetPlayer.rb.velocity = velocity;
    }
    public override void OnCollisionEnter2D(PlayerStateController player, Collision2D collision)
    {
        
    }
    public override void UpdateState(PlayerStateController player)
    {
        if (player.GetModel.Horizontal == 0)
        {
            player.SwitchState(player.IdleState);
        }
        if (player.GetModel.OnGround && player.GetModel.JumpPressed)
        {
            player.SwitchState(player.JumpState);
        }
    }
}
