using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ¬ью хп стен через Image
/// </summary>
[RequireComponent(typeof(Image))]
public class WallsHealthImageView : MonoBehaviour
{
    private AbstractHealth health;

    private Image image;

    private void Awake()
    {
        image = GetComponent<Image>();
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
        image.fillAmount = (float)value / health.MaxHealth;
    }
}
