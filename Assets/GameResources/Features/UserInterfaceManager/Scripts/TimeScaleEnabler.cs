using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Останавливает время при включении объекта
/// </summary>
public class TimeScaleEnabler : MonoBehaviour
{
    private float prevTime = 1f;

    private void OnEnable()
    {
        prevTime = Time.timeScale;
        Time.timeScale = 0;
    }

    private void OnDisable()
    {
        Time.timeScale = prevTime;
    }
}
