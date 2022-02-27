using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Устанавливает максимальное значение фпс
/// </summary>
public class FPSController : MonoBehaviour
{
    [SerializeField]
    private int fpsTarget = 120;

    private void Start()
    {
        Application.targetFrameRate = fpsTarget;
    }
}
