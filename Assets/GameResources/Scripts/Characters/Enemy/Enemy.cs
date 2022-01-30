using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Враг
/// </summary>
public class Enemy : AbstractHealth
{
    protected override void OnHealthChange(int value)
    {
        if (value == 0)
            Destroy(gameObject);
    }
}
