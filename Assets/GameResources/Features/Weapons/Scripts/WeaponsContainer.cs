using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Контейнер оружий
/// </summary>
[CreateAssetMenu(fileName = "Weapons Container", menuName = "Game/Weapons Container Data")]
public class WeaponsContainer : ScriptableObject
{
    public IReadOnlyList<WeaponData> Weapons => weapons;

    [SerializeField]
    private List<WeaponData> weapons;
}
