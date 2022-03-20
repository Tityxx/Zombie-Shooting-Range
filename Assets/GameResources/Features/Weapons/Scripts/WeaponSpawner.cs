using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Спавнер оружия для игрока
/// </summary>
public class WeaponSpawner : MonoBehaviour
{
    [SerializeField]
    private Transform parent;
    [SerializeField]
    private WeaponsContainer container;
    [SerializeField]
    private WeaponData defaultWeapon;

    private void Start()
    {
        SpawnWeapon(FindWeapon());
    }

    private WeaponData FindWeapon()
    {
        foreach (var data in container.Weapons)
        {
            if (data.HaveWeapon && data.IsChoosen)
            {
                return data;
            }
        }

        return defaultWeapon;
    }

    private void SpawnWeapon(WeaponData data)
    {
        Transform trans = Instantiate(data.Prefab, parent).transform;
        trans.localPosition = Vector3.zero;
        trans.localEulerAngles = Vector3.zero;
    }
}
