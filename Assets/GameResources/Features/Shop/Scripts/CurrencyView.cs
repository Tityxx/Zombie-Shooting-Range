using DG.Tweening;
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

    private TMP_Text text;

    private void Awake()
    {
        text = GetComponent<TMP_Text>();
    }

    private void OnEnable()
    {
        text.text = Currency.Value.ToString();
        Currency.onValueChange += OnValueChange;
    }

    private void OnDisable()
    {
        Currency.onValueChange -= OnValueChange;
    }

    private void OnValueChange(int currency)
    {
        text.text = currency.ToString();
        transform.DOScale(Vector3.one * scaleOnChange, durationOnChange / 2).SetEase(Ease.InOutBounce).OnComplete(() => 
        { 
            transform.DOScale(Vector3.one, durationOnChange / 2).SetEase(Ease.InOutBounce); 
        });
    }
}
