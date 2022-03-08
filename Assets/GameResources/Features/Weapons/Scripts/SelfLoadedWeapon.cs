using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Самозарядное оружие (пистолеты и т.п.)
/// </summary>
public class SelfLoadedWeapon : AbstractWeapon
{
    [SerializeField]
    private ParticleSystem shotEffect;

    private float shotTime;
    private bool isShootAnim = false;

    public override void Shoot()
    {
        if (currBullets <= 0)
        {
            ReloadAnim();
            return;
        }

        if (isShootAnim || isReloading || shotTime + data.DelayBetweenShots > Time.time)
            return;
        
        isShootAnim = true;
        anim.SetTrigger(ATTACK_KEY);
        anim.SetBool(RELOAD_KEY, false);
        shotEffect.Play();
        RaycastShoot();
    }

    /// <summary>
    /// Анимация выстрела закончилась
    /// </summary>
    public void EndShootAnim()
    {
        isShootAnim = false;
        shotTime = Time.time;

        if (currBullets <= 0)
        {
            ReloadAnim();
        }
    }
}
