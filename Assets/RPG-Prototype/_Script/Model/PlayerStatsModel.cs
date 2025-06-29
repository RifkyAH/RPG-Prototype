using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using Zenject;
public class PlayerStatsData
{
    public readonly float BaseHealthPoint = 100f;
    public float HealthPoint { get; set; }
}
public class PlayerStatsModel : IInitializable
{
    private PlayerStatsData _statsData;
    public BehaviorSubject<float> _healthChange = new BehaviorSubject<float>(100f);
    public IObservable<float> OnHealtChangeAsObservable()
    {
        return _healthChange.AsObservable();
    } 
    public void Initialize()
    {
        _statsData = new PlayerStatsData();
        InitialData();
    }
    public float MaxHealthPoint
    {
        get => _statsData.BaseHealthPoint;
    }
    public float HealthPoint
    {
        get => _statsData.HealthPoint;
        set => _statsData.HealthPoint = Mathf.Clamp(value, 0, MaxHealthPoint);
    }
    public void InitialData()
    {
        HealthPoint = MaxHealthPoint;
    }
}
