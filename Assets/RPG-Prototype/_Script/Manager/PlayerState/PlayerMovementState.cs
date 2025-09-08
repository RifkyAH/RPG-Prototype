using System;
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
        Debug.Log(Horizontal);
        player.GetPlayer.anim.SetFloat("isRun", Mathf.Abs(Horizontal));
        player.GetPlayer.rb.velocity = new Vector2(Horizontal*player.GetModel.MovementSpeed,player.GetPlayer.rb.velocity.y);
        if (Horizontal > 0 && !player.GetModel.IsFacingRight)
        {
            player.GetPlayer.Flip();
        }
        else if (Horizontal < 0 && player.GetModel.IsFacingRight)
        {
            player.GetPlayer.Flip();
        }
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
        if (player.GetModel.MeleeAttackPressed)
        {
            player.SwitchState(player.AttackState);
        }
        if (player.GetModel.BowAttackPressed)
        {
            player.SwitchState(player.BowState);
        }
    }
}
