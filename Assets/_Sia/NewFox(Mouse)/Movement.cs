using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private CharacterController _controller;

    private Vector2 _movementDirection = Vector2.zero;
    private Rigidbody2D _rigidbody;

    private CharacterStatsHandler _stats;

    //public float jumpPower;

    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _stats = GetComponent<CharacterStatsHandler>();
    }

    private void Start()
    {
        _controller.OnMoveEvent += Move;
    }

    /*void Update()
    {
        if (Input.GetButtonDown("Jump"))
            _rigidbody.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
    }*/

    private void FixedUpdate()
    {
        ApplyMovment(_movementDirection);
    }

    private void Move(Vector2 direction)
    {
        _movementDirection = direction;
    }

    private void ApplyMovment(Vector2 direction)
    {
        //direction = direction * 5;
        direction = direction * _stats.CurrentStates.speed;

        _rigidbody.velocity = direction;
    }
}