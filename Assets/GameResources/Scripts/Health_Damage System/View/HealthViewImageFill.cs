using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Вью здоровья через fill у Image
/// </summary>
[RequireComponent(typeof(Image))]
public class HealthViewImageFill : MonoBehaviour
{
    [SerializeField]
    private AbstractHealth health;

    private Image image;

    private void Awake()
    {
        image = GetComponent<Image>();
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
