using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Вью оружия в магазине
/// </summary>
public class WeaponShopView : MonoBehaviour
{
    [SerializeField]
    private Image icon;
    [SerializeField]
    private Button chooseBtn;
    [SerializeField]
    private Button choosenBtn;
    [SerializeField]
    private Button buyBtn;
    [SerializeField]
    private TMP_Text costText;

    private WeaponData data;

    /// <summary>
    /// Инициализация вью
    /// </summary>
    public void Init(WeaponData data)
    {
        this.data = data;

        icon.transform.localScale = Vector3.one * data.IconScale;

        icon.sprite = data.Icon;
        costText.text = data.Cost.ToString();
        UpdateButtonsView();

        WeaponData.onChooseWeapon += UpdateButtonsView;
        chooseBtn.onClick.AddListener(ChooseWeapon);
        buyBtn.onClick.AddListener(BuyWeapon);
    }

    private void OnDestroy()
    {
        WeaponData.onChooseWeapon -= UpdateButtonsView;
        chooseBtn.onClick.RemoveListener(ChooseWeapon);
        buyBtn.onClick.RemoveListener(BuyWeapon);
    }

    private void UpdateButtonsView()
    {
        chooseBtn.gameObject.SetActive(data.HaveWeapon && !data.IsChoosen);
        choosenBtn.gameObject.SetActive(data.HaveWeapon && data.IsChoosen);
        buyBtn.gameObject.SetActive(!data.HaveWeapon);
    }

    private void BuyWeapon()
    {
        if (Currency.Value >= data.Cost)
        {
            Currency.Value -= data.Cost;
            data.HaveWeapon = true;
            UpdateButtonsView();
        }
        else
        {
            Currency.NotEnoughMoney();
        }
    }

    private void ChooseWeapon()
    {
        data.IsChoosen = true;
    }
}
