using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Базовый класс оружия
/// </summary>
[RequireComponent(typeof(Animator))]
public abstract class AbstractWeapon : MonoBehaviour
{
    public event Action onBulletsCountChange = delegate { };

    public WeaponData WeaponData => data;
    public int CurrBullets => currBullets;

    [SerializeField]
    protected WeaponData data;

    protected Animator anim;

    protected PlayerInput input;
    protected Transform shootingPoint;

    protected int currBullets;
    protected bool isReloading = false;

    protected const string ATTACK_KEY = "IsAttack";
    protected const string RELOAD_KEY = "IsReload";

    protected virtual void Awake()
    {
        anim = GetComponent<Animator>();
        shootingPoint = Camera.main.transform;
        input = new PlayerInput();

        currBullets = data.MaxBullets;
    }

    protected virtual void OnEnable()
    {
        input.Enable();
        input.Input.Shoot.performed += ctx => Shoot();
        input.Input.Reload.performed += ctx => ReloadAnim();
    }

    protected virtual void OnDisable()
    {
        input.Disable();
        input.Input.Shoot.performed -= ctx => Shoot();
        input.Input.Reload.performed -= ctx => ReloadAnim();
    }

    /// <summary>
    /// Нажатие на кнопку выстрела
    /// </summary>
    public abstract void Shoot();

    /// <summary>
    /// Выстрел рейкастом
    /// </summary>
    public void RaycastShoot()
    {
        currBullets--;
        if (Physics.Raycast(shootingPoint.position, shootingPoint.forward, out RaycastHit hit))
        {
            if (hit.transform.TryGetComponent(out AbstractHealth health))
            {
                health.Health -= data.Damage;
            }
            if (hit.transform.TryGetComponent(out ImpactHandler impact))
            {
                impact.Impact(hit.point);
            }
        }
        onBulletsCountChange();
    }

    protected void ReloadAnim()
    {
        isReloading = true;
        anim.SetBool(RELOAD_KEY, true);
    }

    /// <summary>
    /// Окончание перезарядки
    /// </summary>
    public void EndReload()
    {
        isReloading = false;
        currBullets = data.MaxBullets;
        anim.SetBool(RELOAD_KEY, false);
        onBulletsCountChange();
    }
}
