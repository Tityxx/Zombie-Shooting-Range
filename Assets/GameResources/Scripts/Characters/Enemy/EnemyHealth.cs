using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Враг
/// </summary>
public class EnemyHealth : AbstractHealth
{
    private EnemyObjectPool pool;

    public void Init(EnemyObjectPool _pool)
    {
        pool = _pool;
    }

    protected override void OnHealthChange(int value)
    {
        if (value <= 0)
        {
            if (!pool)
            {
                Destroy(gameObject);
                return;
            }
            pool.Release(this);
        }
    }
}
