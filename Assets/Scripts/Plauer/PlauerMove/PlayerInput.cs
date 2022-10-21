using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private PlayerBehavior _playerBehavior;

    private void Start()
    {
        _playerBehavior = GetComponent<PlayerBehavior>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.D))
            _playerBehavior.MoveRight();
        if (Input.GetKey(KeyCode.A))
            _playerBehavior.MoveLeft();
        if (Input.GetKeyDown(KeyCode.Space))
            _playerBehavior.Jump();
    }
}
