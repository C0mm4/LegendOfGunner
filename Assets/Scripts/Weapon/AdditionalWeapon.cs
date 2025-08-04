using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class AdditionalWeapon : RangeWeaponHandler
{
    public BaseWeaponHandler baseWeapon;

    protected override void Start()
    {
        
    }

    public void SetBaseWeapon(BaseWeaponHandler weapon)
    {
        baseWeapon = weapon;
        baseWeapon.attackCallback += ActiveAdditionalAttack;
        baseWeapon.rotateCallback += RotateCallback;
        data = weapon.data;
        rangeData = data as RangeWeaponData;

        projectileSpawn = GameObject.Find("BulletPivot").transform;
        target = weapon.target;

        // Remove Origin WeaponHandler
        Destroy(GetComponent<RangeWeaponHandler>());
    }

    public void ActiveAdditionalAttack()
    {
        Debug.Log(Controller);
        Invoke("Attack", baseWeapon.data.Delay / 2); // 원본 발사 중간에 발사
    }

    public void Update()
    {
        if (baseWeapon == null) return;
        
    }

    public void RotateCallback(bool isLeft)
    {
        Rotate(isLeft);
    }
}
