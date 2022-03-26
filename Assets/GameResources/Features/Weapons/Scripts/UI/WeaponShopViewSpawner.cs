using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Спавн вью оружий для магазина
/// </summary>
public class WeaponShopViewSpawner : MonoBehaviour
{
    [SerializeField]
    private Transform parent;
    [SerializeField]
    private WeaponsContainer container;
    [SerializeField]
    private WeaponShopView prefab;

    private void Awake()
    {
        foreach (var data in container.Weapons)
        {
            Instantiate(prefab, parent).Init(data);
        }
    }
}
