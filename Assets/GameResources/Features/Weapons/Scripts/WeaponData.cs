using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Хранение информации об оружии
/// </summary>
[CreateAssetMenu(menuName = "Game/Weapon Data", fileName = "New Weapon")]
public class WeaponData : ScriptableObject
{
    public int Cost => cost;
    public Sprite Icon => icon;
    public AbstractWeapon Prefab => prefab;
    public bool IsAutomaticWeapon => isAutomaticWeapon;
    public int MaxBullets => maxBullets;
    public int Damage => damage;
    public float DelayBetweenShots => delayBetweenShots;

    public bool HaveWeapon
    {
        get
        {
            string key = string.Format(HAVE_KEY, id);
            return PlayerPrefs.GetInt(key, 0) == 1 || cost == 0;
        }
        set
        {
            string key = string.Format(HAVE_KEY, id);
            PlayerPrefs.SetInt(key, value ? 1 : 0);
            PlayerPrefs.Save();
        }
    }

    public bool IsChoosen
    {
        get
        {
            return PlayerPrefs.GetString(CHOOSEN_KEY) == id;
        }
        set
        {
            PlayerPrefs.SetString(CHOOSEN_KEY, id);
            PlayerPrefs.Save();
        }
    }

    [SerializeField]
    private string id;
    [SerializeField]
    private int cost;

    [Space]
    [Header("Вью")]
    [SerializeField]
    private Sprite icon;
    [SerializeField]
    private AbstractWeapon prefab;

    [Space]
    [Header("Характеристики")]
    [SerializeField]
    private bool isAutomaticWeapon;
    [SerializeField]
    private int maxBullets;
    [SerializeField]
    private int damage;
    [SerializeField]
    private float delayBetweenShots;

    private const string HAVE_KEY = "WeaponData.Have {0} weapon";
    private const string CHOOSEN_KEY = "WeaponData.Choosen weapon";
}