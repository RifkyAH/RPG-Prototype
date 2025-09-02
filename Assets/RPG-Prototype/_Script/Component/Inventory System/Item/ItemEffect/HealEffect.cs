using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

[CreateAssetMenu(menuName = "ItemEffects/Heal")]
public class HealEffect : ItemEffect
{
    [SerializeField] private int healAmount;
    [Inject] private PlayerStatsModel statsModel;
    public override void ApplyEffect(PlayerStatsModel statsModel)
    {
        if (statsModel.HealthPoint <= statsModel.MaxHealthPoint)
        {
            statsModel._healthChange.OnNext(statsModel.HealthPoint += healAmount);
        }
    }
}
