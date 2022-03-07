using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Автоматическое
/// </summary>
public class AutomaticWeapon : AbstractWeapon
{
    [SerializeField]
    private ParticleSystem shotEffect;

    private Coroutine shootingCoroutine = null;
    private float shotTime;

    protected override void OnEnable()
    {
        base.OnEnable();
        input.Input.Shoot.canceled += ctx => CancelShoot();
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        input.Input.Shoot.canceled -= ctx => CancelShoot();
    }

    public override void Shoot()
    {
        if (isReloading)
            return;

        anim.SetBool(ATTACK_KEY, true);
        shootingCoroutine = StartCoroutine(Shooting());
    }

    private void CancelShoot()
    {
        if (shootingCoroutine != null)
        {
            StopCoroutine(shootingCoroutine);
            shootingCoroutine = null;
        }
        shotEffect.Stop();
        anim.SetBool(ATTACK_KEY, false);
    }

    private IEnumerator Shooting()
    {
        while (enabled)
        {
            if (currBullets <= 0)
            {
                ReloadAnim();
                CancelShoot();
                yield break;
            }

            shotEffect.Play();

            RaycastShoot();

            yield return new WaitForSeconds(data.DelayBetweenShots);
        }
    }
}
