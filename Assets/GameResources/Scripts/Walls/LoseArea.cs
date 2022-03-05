using System.Collections;
using System.Collections.Generic;
using ToolsAndMechanics.UserInterfaceManager;
using UnityEngine;

/// <summary>
/// Обработка поражения (вход врагов в зону)
/// </summary>
public class LoseArea : MonoBehaviour
{
    [SerializeField]
    private WindowData window;

    private bool isLose = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!isLose && other.gameObject.TryGetComponent(out EnemyController enemy))
        {
            isLose = true;
            WindowsController.Instance.SetWindow(window, true);
        }
    }
}
