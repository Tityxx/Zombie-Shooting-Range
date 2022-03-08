using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Контроллер таймера уровня
/// </summary>
public class TimerController : MonoBehaviour
{
    /// <summary>
    /// Изменение времени в секундах
    /// </summary>
    public event Action<float> onTimeChange = delegate { };

    public float Time => currTime;

    private float currTime = -1;

    private void Start()
    {
        StartCoroutine(TimerCoroutine());
    }

    private IEnumerator TimerCoroutine()
    {
        while (enabled)
        {
            currTime++;
            onTimeChange(currTime);
            yield return new WaitForSeconds(1f);
        }
    }
}