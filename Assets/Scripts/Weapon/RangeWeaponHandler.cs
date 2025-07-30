using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeWeaponHandler : BaseWeaponHandler
{
    [Header("Ranged Attack Data")]
    [SerializeField]
    private Transform projectileSpawn;

    [SerializeField]
    private GameObject bullet;
    public GameObject Bullet {  get { return bullet; } }

    [SerializeField]
    private float bulletSize = 1f;
    public float BulletSize {  get { return bulletSize; } }

    [SerializeField]
    private float duration;
    public float Duration { get { return duration; } }

    [SerializeField]
    private float spread;
    public float Spread { get { return spread; } }

    [SerializeField]
    private int numProjectilePerShot;
    public int NumProjectilePerShot { get { return numProjectilePerShot; } }

    [SerializeField]
    private float multiProjectileAngle;
    public float MultiProjectileAngle { get { return multiProjectileAngle; } }

    [SerializeField]
    private Color projectileColor;
    public Color ProjectileColor { get { return projectileColor; } }

    protected void Start()
    {

    }

    public override void Attack()
    {
        base.Attack();

        Debug.Log("B");

        float projectileAngleSpace = multiProjectileAngle;
        int numberOfProjectilePerShot = numProjectilePerShot;

        float minAngle = -(numberOfProjectilePerShot / 2f) * projectileAngleSpace;

        for (int i = 0; i < numberOfProjectilePerShot; i++)
        {
            float angle = minAngle + projectileAngleSpace * i;
            float randomSpread = Random.Range(-spread, spread);
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
