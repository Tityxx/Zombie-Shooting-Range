using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/// <summary>
/// Вью денег
/// </summary>
[RequireComponent(typeof(TMP_Text))]
public class CurrencyView : MonoBehaviour
{
    [SerializeField]
    private float durationOnChange = 0.3f;
    [SerializeField]
    private float scaleOnChange = 1.2f;

    private Tween tween;

    private TMP_Text text;

    private void Awake()
    {
        text = GetComponent<TMP_Text>();
    }

    private void OnEnable()
    {
        text.text = Currency.Value.ToString();
        Currency.onValueChange += OnValueChange;
        Currency.onNotEnoughMoney += OnNotEnoughMoney;
    }

    private void OnDisable()
    {
        Currency.onValueChange -= OnValueChange;
        Currency.onNotEnoughMoney -= OnNotEnoughMoney;
    }

    private void OnValueChange(int currency)
    {
        text.text = currency.ToString();

        if (tween != null && tween.IsPlaying()) return;

        tween = transform.DOScale(Vector3.one * scaleOnChange, durationOnChange / 2).SetEase(Ease.InOutBounce).OnComplete(() => 
        {
            tween = transform.DOScale(Vector3.one, durationOnChange / 2).SetEase(Ease.InOutBounce); 
        });
    }

    private void OnNotEnoughMoney()
    {
        text.color = Color.red;

        if (tween != null && tween.IsPlaying()) return;

        tween = transform.DOScale(Vector3.one * scaleOnChange, durationOnChange / 2).SetEase(Ease.InOutBounce).OnComplete(() =>
        {
            tween = transform.DOScale(Vector3.one, durationOnChange / 2).SetEase(Ease.InOutBounce).OnComplete(() => {
                text.color = Color.white;
            });
        });
    }
}
