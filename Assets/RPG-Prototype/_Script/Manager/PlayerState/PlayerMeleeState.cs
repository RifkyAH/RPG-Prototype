using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMeleeState : PlayerBaseState
{
    public override void EnterState(PlayerStateController player)
    {
        player.GetPlayer.anim.SetBool("isAttack", true);
    }
    public override void FixedUpdateState(PlayerStateController player)
    {
        
    }
    public override void OnCollisionEnter2D(PlayerStateController player, Collision2D collision)
    {
        
    }
    public override void UpdateState(PlayerStateController player)
    {
        if (!player.GetModel.MeleeAttackPressed)
        {
            player.GetPlayer.anim.SetBool("isAttack",false);
            player.SwitchState(player.LastState);       
        }
    }
}
