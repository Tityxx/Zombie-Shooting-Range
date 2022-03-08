using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/// <summary>
/// ¬ью хп стен через Image
/// </summary>
[RequireComponent(typeof(TMP_Text))]
public class WallsHealthTextView : MonoBehaviour
{
    private AbstractHealth health;

    private TMP_Text text;

    private void Awake()
    {
        text = GetComponent<TMP_Text>();
        health = FindObjectOfType<WallsController>();
    }

    private void OnEnable()
    {
        OnHealthChange(health.Health);
        health.onHealthChange += OnHealthChange;
    }

    private void OnDisable()
    {
        health.onHealthChange -= OnHealthChange;
    }

    private void OnHealthChange(int value)
    {
        text.text = $"{value} / {health.MaxHealth}";
    }
}
