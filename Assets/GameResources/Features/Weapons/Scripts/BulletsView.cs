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

    private bool isSubscribe = false;

    private IEnumerator Start()
    {
        yield return new WaitWhile(() => (weapon = FindObjectOfType<AbstractWeapon>()) == null);

        text = GetComponent<TMP_Text>();
        Subscribe();
    }

    private void OnEnable()
    {
        Subscribe();
    }

    private void Subscribe()
    {
        if (!isSubscribe && weapon != null)
        {
            OnShoot();
            weapon.onBulletsCountChange += OnShoot;
            isSubscribe = true;
        }
    }

    private void OnDisable()
    {
        isSubscribe = false;
        if (weapon != null)
            weapon.onBulletsCountChange -= OnShoot;
    }

    private void OnShoot()
    {
        text.text = $"{weapon.CurrBullets} / {weapon.WeaponData.MaxBullets}";
    }
}
