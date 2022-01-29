using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Движение игрока
/// </summary>
[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed;

    private PlayerInput input;
    private Rigidbody rb;

    private Vector2 move;

    private void Awake()
    {
        input = new PlayerInput();
        rb = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        input.Enable();
    }

    private void OnDisable()
    {
        input.Disable();
    }

    private void FixedUpdate()
    {
        move = new Vector2(Mathf.RoundToInt(input.Input.Movement.ReadValue<Vector2>().x), Mathf.RoundToInt(input.Input.Movement.ReadValue<Vector2>().y));
        Vector2 velocity = move * movementSpeed * Time.fixedDeltaTime;
        rb.AddRelativeForce(new Vector3(velocity.x, rb.velocity.y, velocity.y), ForceMode.VelocityChange);
        if (velocity == Vector2.zero)
        {
            rb.velocity = Vector3.zero;
        }
    }
}
