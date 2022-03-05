using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Устанавливает режим окна
/// </summary>
public class FullscreenModeSetter : MonoBehaviour
{
    [SerializeField]
    private FullScreenMode mode = FullScreenMode.ExclusiveFullScreen;

    private void Start()
    {
        Screen.fullScreenMode = mode;
    }
}
