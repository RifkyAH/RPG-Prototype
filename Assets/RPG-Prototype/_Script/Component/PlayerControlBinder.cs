using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControlBinder : MonoBehaviour
{
    private Subject<float> _horizontalMovement;
    public IObservable<float> OnHorizontalMovementAsObservable()
    {
        return _horizontalMovement.AsObservable();
    }
    private void Awake()
    {
        _horizontalMovement = new Subject<float>();
    }
    private void OnMove(InputValue value)
    {
        float axisx = value.Get<Vector2>().x;
        _horizontalMovement.OnNext(axisx);
    }
}
