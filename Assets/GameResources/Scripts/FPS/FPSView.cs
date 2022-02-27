using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/// <summary>
/// Показывает колличество фпс
/// </summary>
[RequireComponent(typeof(TMP_Text))]
public class FPSView : MonoBehaviour
{
    private TMP_Text text;

    private void Awake()
    {
        text = GetComponent<TMP_Text>();
    }

    private void Update()
    {
        text.text = (1 / Time.unscaledDeltaTime).ToString();
    }
}
