using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerStateManager : MonoBehaviour
{
    [Inject] PlayerStateController _controller;
    [SerializeField] private Rigidbody2D _rb;
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
    public Rigidbody2D rb{ get => _rb; }
}
