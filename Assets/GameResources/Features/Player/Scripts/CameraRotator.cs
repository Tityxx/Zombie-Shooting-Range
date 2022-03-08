using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Вращает игрока и камеру
/// </summary>
public class CameraRotator : MonoBehaviour
{
    [SerializeField]
    private float mouseSensivity;
    [SerializeField]
    private Transform player;
    [SerializeField]
    private List<Vector2> limits;

    private PlayerInput input;
    private Vector2 mouseInput;

    private void Awake()
    {
        input = new PlayerInput();
    }

    private void OnEnable()
    {
        input.Enable();
    }

    private void OnDisable()
    {
        input.Disable();
    }

    private void Update()
    {
        mouseInput = input.Input.CameraView.ReadValue<Vector2>();
        Vector2 mouse = mouseInput * mouseSensivity * Time.deltaTime;

        transform.localRotation = Quaternion.Euler(Clamp(transform.eulerAngles.x - mouse.y, transform.eulerAngles.x), 0, 0);
        player.Rotate(Vector3.up * mouse.x);
    }

    private float Clamp(float angle, float defaultAngle)
    {
        foreach (Vector2 limit in limits)
        {
            if (angle.IsBetween(limit.x, limit.y))
            {
                return angle;
            }
        }

        return defaultAngle;
    }
}
