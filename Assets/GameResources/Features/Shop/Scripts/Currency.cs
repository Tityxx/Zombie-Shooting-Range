using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

/// <summary>
/// Валюта
/// </summary>
public static class Currency
{
    public static event Action<int> onValueChange = delegate { };
    public static event Action onNotEnoughMoney = delegate { };

    public static int Value
    {
        get
        {
            return PlayerPrefs.GetInt(SAVE_KEY, 0);
        }
        set
        {
            if (value != Value)
            {
                PlayerPrefs.SetInt(SAVE_KEY, Mathf.Clamp(value, 0, int.MaxValue));
                PlayerPrefs.Save();
                onValueChange(Value);
            }
        }
    }

    public static void NotEnoughMoney()
    {
        onNotEnoughMoney();
    }

    [MenuItem("Tools/Game/Currency/Add 1000")]
    private static void AddMoney_1000()
    {
        Value += 1000;
    }

    [MenuItem("Tools/Game/Currency/Add 5000")]
    private static void AddMoney_5000()
    {
        Value += 5000;
    }

    [MenuItem("Tools/Game/Currency/Remove 1000")]
    private static void RemoveMoney_1000()
    {
        Value -= 1000;
    }

    [MenuItem("Tools/Game/Currency/Remove 5000")]
    private static void RemoveMoney_5000()
    {
        Value -= 5000;
    }

    [MenuItem("Tools/Game/Currency/Debug")]
    private static void DebugMoney()
    {
        Debug.Log($"Currency = {Value}");
    }

    private const string SAVE_KEY = "Currency value";
}
