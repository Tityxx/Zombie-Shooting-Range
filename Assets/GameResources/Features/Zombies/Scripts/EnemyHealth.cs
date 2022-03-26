using System.Collections;
using System.Collections.Generic;
using ToolsAndMechanics.ObjectPool;
using UnityEngine;

/// <summary>
/// Хп врага
/// </summary>
public class EnemyHealth : AbstractHealth
{
    [Header("Задержка перед возвращением в пул после смерти")]
    [SerializeField]
    private float delay = 5;
    [Header("Награда за убийство")]
    [SerializeField]
    private int rewardCurrency = 5;

    protected override void OnHealthChange(int value)
    {
        if (!isDead && value <= 0)
        {
            Currency.Value += rewardCurrency;
            Invoke(nameof(ReturnToPool), delay);
        }
    }

    private void ReturnToPool()
    {
        health = maxHealth;
        if (TryGetComponent(out PoolInformation info))
        {
            info.ReturnToPool();
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
