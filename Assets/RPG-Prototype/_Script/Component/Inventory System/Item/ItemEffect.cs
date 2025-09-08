using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemEffect : ScriptableObject
{
    public abstract void ApplyEffect(PlayerStatsModel statsModel);
}
