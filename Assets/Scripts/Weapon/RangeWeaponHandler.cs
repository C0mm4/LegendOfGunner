using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeWeaponHandler : BaseWeaponHandler
{
    [Header("Ranged Attack Data")] 
    protected RangeWeaponData rangeData;
    [SerializeField]
    protected Transform projectileSpawn;

    public GameObject Bullet {  get { return rangeData.Bullet; } }

    public float BulletSize {  get { return rangeData.BulletSize; } }

    public float Duration { get { return rangeData.Duration; } }

    public float Spread { get { return rangeData.Spread; } }

    public int NumProjectilePerShot { get { return rangeData.NumProjectilePerShot; } }

    public float MultiProjectileAngle { get { return rangeData.MultiProjectileAngle; } }

    public Color ProjectileColor { get { return rangeData.ProjectileColor; } }
    
    protected override void Start()
    {
        base.Start();
        rangeData = data as RangeWeaponData;
    }

    public override void Attack()
    {
        if (!gameObject.activeSelf) return;
        if (rangeData == null) return;
        base.Attack();
        float projectileAngleSpace = 0;
        int numberOfProjectilePerShot = rangeData.NumProjectilePerShot;

        float minAngle = -(numberOfProjectilePerShot / 2f) * projectileAngleSpace;

        for (int i = 0; i < numberOfProjectilePerShot; i++)
        {
            float angle = minAngle + projectileAngleSpace * i;
            float randomSpread = Random.Range(-rangeData.Spread, rangeData.Spread);
            angle += randomSpread;

            CreateProjectile(Controller.LookDirection, angle);
        }
    }

    private void CreateProjectile(Vector2 _lookDir, float angle)
    {
        ProjectileManager.Instance?.ShootBullet(this, projectileSpawn.position, RotateVector2(_lookDir, angle));
    }

    private static Vector2 RotateVector2(Vector2 v, float degree)
    {
        return Quaternion.Euler(0, 0, degree) * v;
    }
}
