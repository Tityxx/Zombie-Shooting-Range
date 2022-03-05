using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Хп врага
/// </summary>
public class EnemyHealth : AbstractHealth
{
    [Header("Задержка перед возвращением в пул после смерти")]
    [SerializeField]
    private float delay = 5;

    private EnemyObjectPool pool;

    public void Init(EnemyObjectPool _pool)
    {
        pool = _pool;
    }

    protected override void OnHealthChange(int value)
    {
        if (!isDead && value <= 0)
        {
            Invoke(nameof(ReturnToPool), delay);
        }
    }

    private void ReturnToPool()
    {
        pool.Release(this);
        health = maxHealth;
    }
}
