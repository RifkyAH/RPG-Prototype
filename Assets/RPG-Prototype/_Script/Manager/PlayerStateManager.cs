using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerStateManager : MonoBehaviour,IDamageable
{
    [Inject] PlayerStateController _controller;
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private Animator _anim;
    [SerializeField] private Transform _playerBody;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {
        _controller.CurrentState.UpdateState(_controller);
    }
    private void FixedUpdate()
    {
        _controller.CurrentState.FixedUpdateState(_controller);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        _controller.CurrentState.OnCollisionEnter2D(_controller, collision);
        if (collision.gameObject.CompareTag("Ground"))
        {
            _controller.GetModel.OnGround = true;
        }
    }
    public void Flip()
    {
        _controller.GetModel.IsFacingRight = !_controller.GetModel.IsFacingRight;

        Vector3 scale = _playerBody.localScale;
        scale.x *= -1;
        _playerBody.localScale = scale;
    }
    public void TakeDamage(float amount)
    {
        _controller.GetStats.HealthPoint -= amount;
        _controller.GetStats._healthChange.OnNext(_controller.GetStats.HealthPoint);
    }

    public Rigidbody2D rb { get => _rb; }
    public Animator anim { get => _anim; }
    public Transform playerBody { get => _playerBody;}
}
