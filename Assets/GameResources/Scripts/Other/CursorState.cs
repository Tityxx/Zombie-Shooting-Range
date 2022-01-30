using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Переключает состояние курсора по нажатию на Esc
/// </summary>
public class CursorState : MonoBehaviour
{
    private PlayerInput input;

    private bool isVisible = true;

    private void Awake()
    {
        input = new PlayerInput();
    }

    private void OnEnable()
    {
        input.Enable();
        input.Input.CursorState.started += ctx => ChangeState();
    }

    private void OnDisable()
    {
        input.Disable();
        input.Input.CameraView.started -= ctx => ChangeState();
    }

    private void ChangeState()
    {
        Cursor.visible = !Cursor.visible;
        Cursor.lockState = Cursor.visible ? CursorLockMode.None : CursorLockMode.Locked;
    }
}
