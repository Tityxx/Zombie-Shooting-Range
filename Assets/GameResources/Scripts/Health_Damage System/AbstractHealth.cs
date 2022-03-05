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

    /// <summary>
    /// Максимальное хп
    /// </summary>
    public int MaxHealth => maxHealth == -1 ? health : maxHealth;

    /// <summary>
    /// Закончилось ли хп у объекта
    /// </summary>
    public bool IsDead => isDead;

    public int Health 
    {
        get
        {
            return health;
        }
        set
        {
            if (health == value || isDead)
                return;

            health = Mathf.Clamp(value, 0, maxHealth);
            OnHealthChange(health);
            onHealthChange(health);
            if (health == 0)
            {
                isDead = true;
                onHealthIsOver();
            }
        }
    }

    [SerializeField]
    protected int health;

    protected int maxHealth = -1;
    protected bool isDead = false;

    protected virtual void Awake()
    {
        maxHealth = health;
    }

    protected virtual void OnEnable()
    {
        Health = maxHealth;
        isDead = false;
    }

    /// <summary>
    /// Вызвается при изменении хп
    /// </summary>
    /// <param name="value"></param>
    protected abstract void OnHealthChange(int value);
}
