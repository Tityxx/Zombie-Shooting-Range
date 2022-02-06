using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Базовый класс здоровья
/// </summary>
public abstract class AbstractHealth : MonoBehaviour
{
    /// <summary>
    /// Изменение здоровья
    /// </summary>
    public event Action<int> onHealthChange = delegate { };

    /// <summary>
    /// Здоровье закончилось
    /// </summary>
    public event Action onHealthIsOver = delegate { };

    public int MaxHealth => maxHealth == -1 ? health : maxHealth;

    public int Health 
    {
        get
        {
            return health;
        }
        set
        {
            if (health == value)
                return;

            health = Mathf.Clamp(value, 0, maxHealth);
            onHealthChange(health);
            if (health == 0)
            {
                onHealthIsOver();
            }
            OnHealthChange(health);
        }
    }

    [SerializeField]
    protected int health;

    protected int maxHealth = -1;

    protected void Awake()
    {
        maxHealth = health;
    }

    protected void OnEnable()
    {
        health = maxHealth;
    }

    /// <summary>
    /// Вызвается, когда закончилось хп
    /// </summary>
    /// <param name="value"></param>
    protected abstract void OnHealthChange(int value);
}
