using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPauseState : PlayerBaseState
{
    public override void EnterState(PlayerStateController player)
    {
        Time.timeScale = 0;
        if (player.GetModel.CurrentGameState == GameStateManager.GameState.Inventory)
        {
            player.GetView.InventoryUI.SetActive(true);
        }
        else if (player.GetModel.CurrentGameState == GameStateManager.GameState.Pause)
        {
            // unable Pause UI
        }
    }
    public override void FixedUpdateState(PlayerStateController player)
    {
        
    }
    public override void OnCollisionEnter2D(PlayerStateController player, Collision2D collision)
    {
        
    }
    public override void UpdateState(PlayerStateController player)
    {
        if (player.GetModel.CurrentGameState == GameStateManager.GameState.Playing)
        {
            player.GetView.InventoryUI.SetActive(false);
            Time.timeScale = 1;
            player.SwitchState(player.LastState);
        }
    }
}
