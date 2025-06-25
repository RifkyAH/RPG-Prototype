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
        Vector2 Movement = new Vector2(Horizontal, 0) * player.GetModel.MovementSpeed;
        player.GetPlayer.rb.MovePosition(player.GetPlayer.rb.position+Movement*Time.fixedDeltaTime);
    }
    public override void OnCollisionEnter(PlayerStateController player, Collision collision)
    {
        
    }
    public override void UpdateState(PlayerStateController player)
    {
        if (player.GetModel.Horizontal == 0)
        {
            player.SwitchState(player.IdleState);
        }
    }
}
