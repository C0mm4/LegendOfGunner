using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeWeaponHandler : BaseWeaponHandler
{
    [Header("Ranged Attack Data")] 
    RangeWeaponData rangeData;
    [SerializeField]
    private Transform projectileSpawn;

    public GameObject Bullet {  get { return rangeData.Bullet; } }

    public float BulletSize {  get { return rangeData.BulletSize; } }

    public float Duration { get { return rangeData.Duration; } }

    public float Spread { get { return rangeData.Spread; } }

    public int NumProjectilePerShot { get { return rangeData.NumProjectilePerShot; } }

    public float MultiProjectileAngle { get { return rangeData.MultiProjectileAngle; } }

    public Color ProjectileColor { get { return rangeData.ProjectileColor; } }
    
    protected void Start()
    {
        rangeData = data as RangeWeaponData;
    }

    public override void Attack()
    {
        base.Attack();

        float projectileAngleSpace = rangeData.MultiProjectileAngle;
        int numberOfProjectilePerShot = rangeData.NumProjectilePerShot;

        float minAngle = -(numberOfProjectilePerShot / 2f) * projectileAngleSpace;

        for (int i = 0; i < numberOfProjectilePerShot; i++)
        {
            float angle = minAngle + projectileAngleSpace * i;
            float randomSpread = Random.Range(-rangeData.Spread, rangeData.Spread);
            angle += randomSpread;

            Debug.Log(Controller.LookDirection);
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
