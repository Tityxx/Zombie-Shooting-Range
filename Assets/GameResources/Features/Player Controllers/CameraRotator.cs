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
    private Transform cameraHolder;
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
        input.Input.CameraView.performed += ctx => RotateCamera(ctx.ReadValue<Vector2>());
    }

    private void OnDisable()
    {
        input.Disable();
        input.Input.CameraView.performed -= ctx => RotateCamera(ctx.ReadValue<Vector2>());
    }

    private void LateUpdate()
    {
        Vector2 rotation = mouseInput * mouseSensivity * Time.deltaTime;
        transform.eulerAngles += new Vector3(0, rotation.x, 0);
        cameraHolder.eulerAngles += new Vector3(CanRotateCamera(cameraHolder.eulerAngles.x - rotation.y) ? -rotation.y : 0, 0, 0);
    }
    private void RotateCamera(Vector2 mouseInput)
    {
        this.mouseInput = mouseInput;
    }

    private bool CanRotateCamera(float angle)
    {
        foreach (Vector2 limit in limits)
        {
            if (angle.IsBetween(limit.x, limit.y))
            {
                return true;
            }
        }
        return false;
    }
}
