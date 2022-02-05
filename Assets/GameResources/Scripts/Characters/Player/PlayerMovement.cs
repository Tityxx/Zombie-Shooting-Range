using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Движение игрока
/// </summary>
[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed;
    [SerializeField]
    private float jumpHeight;
    [SerializeField]
    private float weight = 2;
    [SerializeField]
    private Transform groundCheck;
    [SerializeField]
    private float radius;
    [SerializeField]
    private LayerMask groundMask;

    private PlayerInput input;
    private CharacterController controller;

    private Vector2 moveInput;
    private Vector3 velocityY;

    private bool isGround;

    private const float GRAVITY = -9.81f;

    private void Awake()
    {
        input = new PlayerInput();
        controller = GetComponent<CharacterController>();
    }

    private void OnEnable()
    {
        input.Enable();
        input.Input.Jump.performed += ctx => Jump();
    }

    private void OnDisable()
    {
        input.Disable();
        input.Input.Jump.performed -= ctx => Jump();
    }

    private void FixedUpdate()
    {
        isGround = Physics.CheckSphere(groundCheck.position, radius, groundMask);
        if (isGround && velocityY.y < 0)
        {
            velocityY.y = -1;
        }

        moveInput = new Vector2(Mathf.RoundToInt(input.Input.Movement.ReadValue<Vector2>().x), Mathf.RoundToInt(input.Input.Movement.ReadValue<Vector2>().y));
        Vector3 velocity = transform.right * moveInput.x + transform.forward * moveInput.y;
        controller.Move(velocity * movementSpeed * Time.fixedDeltaTime);

        velocityY.y += GRAVITY * weight * Time.fixedDeltaTime;
        controller.Move(velocityY * Time.fixedDeltaTime);
    }

    private void Jump()
    {
        if (isGround)
        {
            velocityY.y = Mathf.Sqrt(jumpHeight * -2 * GRAVITY * weight);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(groundCheck.position, radius);
    }
}
