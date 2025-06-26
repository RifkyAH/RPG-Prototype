using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerBaseState
{
    public override void EnterState(PlayerStateController player)
    {
    }
    public override void FixedUpdateState(PlayerStateController player)
    {
        player.GetPlayer.anim.SetFloat("isRun", Mathf.Abs(player.GetModel.Horizontal));
    }
    public override void OnCollisionEnter2D(PlayerStateController player, Collision2D collision)
    {
        
    }
    public override void UpdateState(PlayerStateController player)
    {
        if (player.GetModel.Horizontal != 0)
        {
            player.SwitchState(player.MovementState);
        }
        if (player.GetModel.OnGround && player.GetModel.JumpPressed)
        {
            player.SwitchState(player.JumpState);
        }
    }
}
