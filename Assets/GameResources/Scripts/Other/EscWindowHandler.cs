using System;
using System.Collections;
using System.Collections.Generic;
using ToolsAndMechanics.UserInterfaceManager;
using UnityEngine;

/// <summary>
/// Открытие/закрытие окна по нажатию на эскейп
/// </summary>
public class EscWindowHandler : MonoBehaviour
{
    [SerializeField]
    private WindowData window;
    [SerializeField]
    private bool needClose;

    private PlayerInput input;
    private bool isClose = false;

    private void Awake()
    {
        input = new PlayerInput();
    }

    private void OnEnable()
    {
        input.Enable();
        input.Input.Esc.performed += ctx => Press();
    }

    private void OnDisable()
    {
        input.Input.Esc.performed -= ctx => Press();
        input.Disable();
        isClose = false;
    }

    private void Press()
    {
        if (!isClose)
        {
            isClose = true;
            WindowsController.Instance.SetWindow(window, needClose);
        }
    }
}
