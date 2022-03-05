using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Переключает состояние курсора при открытии/закрытии окон
/// </summary>
public class CursorState : MonoBehaviour
{
    [SerializeField]
    private bool visibleOnEnable = true;

    private void OnEnable()
    {
        ChangeState(visibleOnEnable);
    }

    private void ChangeState(bool isVisible)
    {
        Cursor.visible = isVisible;
        Cursor.lockState = isVisible ? CursorLockMode.None : CursorLockMode.Locked;
    }
    private void OnApplicationFocus(bool hasFocus)
    {
        if (hasFocus)
        {
            ChangeState(visibleOnEnable);
        }
    }
}
