using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/// <summary>
/// Вью таймера
/// </summary>
[RequireComponent(typeof(TMP_Text))]
public class TimerView : MonoBehaviour
{
    private TimerController timer;
    private TMP_Text text;

    private void Awake()
    {
        timer = FindObjectOfType<TimerController>();
        text = GetComponent<TMP_Text>();
    }

    private void OnEnable()
    {
        OnTimeChange(timer.Time);
        timer.onTimeChange += OnTimeChange;
    }

    private void OnDisable()
    {
        timer.onTimeChange -= OnTimeChange;
    }

    private void OnTimeChange(float time)
    {
        TimeSpan timespan = TimeSpan.FromSeconds(time);
        text.text = timespan.ToString(@"mm\:ss");
    }
}
