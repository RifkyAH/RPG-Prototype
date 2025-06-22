using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerBaseState
{
    public abstract void EnterState(PlayerStateController player);
    public abstract void UpdateState(PlayerStateController player);
    public abstract void FixedUpdateState(PlayerStateController player);
    public abstract void OnCollisionEnter(PlayerStateController player, Collision collision);
}
