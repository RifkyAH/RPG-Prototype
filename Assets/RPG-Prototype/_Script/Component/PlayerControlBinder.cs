using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerControlBinder : MonoBehaviour
{
    private Subject<float> _horizontalMovement;
    private UnityEvent _Jump;
    public IObservable<float> OnHorizontalMovementAsObservable()
    {
        return _horizontalMovement.AsObservable();
    }
    public IObservable<Unit> OnJumpAsObservable()
    {
        return _Jump.AsObservable();
    }
    private void Awake()
    {
        _horizontalMovement = new Subject<float>();
        _Jump = new UnityEvent();
    }
    private void OnMove(InputValue value)
    {
        float axisx = value.Get<Vector2>().x;
        _horizontalMovement.OnNext(axisx);
    }
    private void OnJump(InputValue value)
    {
        _Jump?.Invoke();
    }
}
