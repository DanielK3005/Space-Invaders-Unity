using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    //movment fields.
    [SerializeField] private float moveSpeed = 15f;
    private Vector2 _moveInput;
    private Vector3 _delta;
    private Vector3 _newPosition;

    //bounds fields.
    private Vector2 _minBounds;
    private Vector2 _maxBounds;
    private Camera _mainCamera;
    private const float SidePadding = 0.5f;
    private const int UpPadding = -5;
    private const int DownPadding = 7;

    private void Start()
    {
        InitBoundes();
    }

    private void InitBoundes()
    {
        _mainCamera = Camera.main;
        _minBounds = _mainCamera.ViewportToWorldPoint(new Vector2(0, 0));
        _maxBounds = _mainCamera.ViewportToWorldPoint(new Vector2(1, 1));
    }

    void Update()
    {
        Move();
    }
    
    //Get the value of the player movement that the user entered
    void OnMove(InputValue value)
    {
        _moveInput = value.Get<Vector2>();
    }
    
    //the actual movment calculation of the player - on update.
    private void Move()
    {
        _delta = (_moveInput * (moveSpeed * Time.deltaTime));
        _newPosition.x = Mathf.Clamp(transform.position.x + _delta.x, _minBounds.x + SidePadding, _maxBounds.x - SidePadding);
        _newPosition.y = Mathf.Clamp(transform.position.y + _delta.y, _minBounds.y + DownPadding, _maxBounds.y - UpPadding);
        transform.position = _newPosition;
    }
}
