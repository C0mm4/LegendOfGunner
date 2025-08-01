using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileManager : MonoSingleton<ProjectileManager>
{

    protected override void Awake()
    {
        base.Awake();

        
    }


    [SerializeField]
    private ParticleSystem impactParticleSystem;

    public void ShootBullet(RangeWeaponHandler weapon, Vector2 startPos, Vector2 dir)
    {
        //GameObject origin = weapon.Bullet;
        //GameObject projectile = Instantiate(origin, startPos, Quaternion.identity);
        //
        //ProjectileController controller = projectile.GetComponent<ProjectileController>();
        //controller.Init(dir, weapon, this);
    }

    public void CreateImpactParticle(Vector3 pos, RangeWeaponHandler weapon)
    {
        impactParticleSystem.transform.position = pos;
        ParticleSystem.EmissionModule em = impactParticleSystem.emission;
        em.SetBurst(0, new ParticleSystem.Burst(0, Mathf.Ceil(weapon.BulletSize * 5)));

        ParticleSystem.MainModule mainModule = impactParticleSystem.main;
        mainModule.startSpeedMultiplier = weapon.BulletSize * 10f;
        impactParticleSystem.Play();
    }
}
