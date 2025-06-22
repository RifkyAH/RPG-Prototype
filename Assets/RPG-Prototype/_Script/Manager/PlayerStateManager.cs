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
    private void OnCollisionEnter(Collision collision)
    {
        _controller.CurrentState.OnCollisionEnter(_controller, collision);
    }
    public Rigidbody2D rb{ get => _rb; }
}
