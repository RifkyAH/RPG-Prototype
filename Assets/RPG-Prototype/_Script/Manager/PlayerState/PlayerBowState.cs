using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBowState : PlayerBaseState
{
    public override void EnterState(PlayerStateController player)
    {
        player.GetPlayer.anim.SetBool("bowAttack", true);
    }
    public override void FixedUpdateState(PlayerStateController player)
    {
        
    }
    public override void OnCollisionEnter2D(PlayerStateController player, Collision2D collision)
    {
        
    }
    public override void UpdateState(PlayerStateController player)
    {
        if (!player.GetModel.BowAttackPressed)
        {
            player.GetPlayer.anim.SetBool("bowAttack",false);
            player.SwitchState(player.IdleState);       
        }
    }
}
