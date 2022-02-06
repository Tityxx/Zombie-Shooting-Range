using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Пул врагов
/// </summary>
public class EnemyObjectPool : AbstractObjectPool<EnemyHealth>
{
    protected override EnemyHealth CreatePooledItem()
    {
        EnemyHealth obj = Instantiate(prefab);
        obj.Init(this);
        return obj;
    }

    protected override void OnReturnedToPool(EnemyHealth obj)
    {
        obj.Health = obj.MaxHealth;
        obj.gameObject.SetActive(false);
    }

    protected override void OnTakeFromPool(EnemyHealth obj)
    {
        obj.gameObject.SetActive(true);
    }
}
