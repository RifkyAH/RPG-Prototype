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

    }
    public override void OnCollisionEnter(PlayerStateController player, Collision collision)
    {

    }
    public override void UpdateState(PlayerStateController player)
    {
        if (player.GetModel.Horizontal != 0)
        {
            player.SwitchState(player.MovementState);
        }
    }
}
