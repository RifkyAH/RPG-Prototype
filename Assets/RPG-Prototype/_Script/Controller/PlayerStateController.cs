using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using Zenject;

public class PlayerStateController : IInitializable, IDisposable
{
    [Inject] PlayerControlBinder _input;
    [Inject] PlayerStateManager _player;
    [Inject] PlayerStateModel _model;
    [Inject] PlayerStatsModel _stats;
    [Inject] PlayerView _view;

    public PlayerIdleState IdleState = new PlayerIdleState();
    public PlayerMovementState MovementState = new PlayerMovementState();
    public PlayerJumpState JumpState = new PlayerJumpState();
    public PlayerMeleeState AttackState = new PlayerMeleeState();
    public PlayerBowState BowState = new PlayerBowState();
    public PlayerBaseState CurrentState;
    public PlayerBaseState LastState;
    private CompositeDisposable _disposables;
    public void Dispose()
    {
        _disposables?.Dispose();
    }
    public void Initialize()
    {
        _disposables = new CompositeDisposable();
        _input.OnHorizontalMovementAsObservable().Subscribe(_ => HorizontalMovement(_)).AddTo(_disposables);
        _input.OnJumpAsObservable().Subscribe(_ => Jump()).AddTo(_disposables);
        _input.OnMeleeAttackAsObservable().Subscribe(_ => MeleeAttack()).AddTo(_disposables);
        _input.OnBowAttackAsObservable().Subscribe(_ => BowAttack()).AddTo(_disposables);

        _stats.OnHealtChangeAsObservable().Subscribe(_ => healthChange(_)).AddTo(_disposables);
        SwitchState(IdleState);
        CurrentState = IdleState;
    }
    private void HorizontalMovement(float _)
    {
        _model.Horizontal = _;
    }
    private void Jump()
    {
        _model.JumpPressed = true;
    }
    private void MeleeAttack()
    {
        _model.MeleeAttackPressed = true;
    }
    private void BowAttack()
    {
        _model.BowAttackPressed = true;
    }
    private void healthChange(float HealthPoint)
    {
        _view.HealthUI.text = "Health : " + HealthPoint;
    }
    public void SwitchState(PlayerBaseState state)
    {
        if (CurrentState != state)
        {
            LastState = CurrentState;
            CurrentState = state;

            state.EnterState(this);
        }
    }
    public PlayerStateManager GetPlayer { get => _player; }
    public PlayerStateModel GetModel { get => _model; }
    public PlayerStatsModel GetStats { get => _stats; }
}
