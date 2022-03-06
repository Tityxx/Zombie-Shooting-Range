using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/// <summary>
/// Отображение колличества патронов
/// </summary>
[RequireComponent(typeof(TMP_Text))]
public class BulletsView : MonoBehaviour
{
    private AbstractWeapon weapon;
    private TMP_Text text;

    private void Awake()
    {
        weapon = FindObjectOfType<AbstractWeapon>();
        text = GetComponent<TMP_Text>();
    }

    private void OnEnable()
    {
        OnShoot();
        weapon.onBulletsCountChange += OnShoot;
    }

    private void OnDisable()
    {
        weapon.onBulletsCountChange -= OnShoot;
    }

    private void OnShoot()
    {
        text.text = $"{weapon.CurrBullets} / {weapon.WeaponData.MaxBullets}";
    }
}
