using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "RangeWeaponData", menuName = "Weapon Data/RangeWeaponData")]
public class RangeWeaponData : WeaponData
{
    [Header("Ranged Attack Data")]

    [SerializeField]
    private GameObject bullet;
    public GameObject Bullet { get { return bullet; } }

    [SerializeField]
    private float bulletSize = 1f;
    public float BulletSize { get { return bulletSize; } }

    [SerializeField]
    private float duration;
    public float Duration { get { return duration; } }

    [SerializeField]
    private float spread;
    public float Spread { get { return spread; } }

    [SerializeField]
    private int numProjectilePerShot;
    public int NumProjectilePerShot { get { return numProjectilePerShot; } set { numProjectilePerShot = value; } }

    [SerializeField]
    private float multiProjectileAngle;
    public float MultiProjectileAngle { get { return multiProjectileAngle; } }

    [SerializeField]
    private Color projectileColor;
    public Color ProjectileColor { get { return projectileColor; } }

}
