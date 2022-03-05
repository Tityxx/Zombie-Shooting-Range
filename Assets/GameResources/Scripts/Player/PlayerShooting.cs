using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Стрельба игрока
/// TODO: Разделить логику стрельбы, дамаг и вью
/// </summary>
public class PlayerShooting : MonoBehaviour
{
    [SerializeField]
    private int damage;

    private PlayerInput input;
    private Transform shootingPoint;

    private void Awake()
    {
        shootingPoint = Camera.main.transform;
        input = new PlayerInput();
    }

    private void OnEnable()
    {
        input.Enable();
        input.Input.Shoot.performed += ctx => Shoot();
    }

    private void OnDisable()
    {
        input.Disable();
        input.Input.Shoot.performed -= ctx => Shoot();
    }

    private void Shoot()
    {
        if (Physics.Raycast(shootingPoint.position, shootingPoint.forward, out RaycastHit hit))
        {
            if (hit.transform.TryGetComponent(out AbstractHealth health))
            {
                health.Health -= damage;
            }
        }
    }
}
