using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MeleeWeaponData", menuName = "Weapon Data/MeleeWeaponData")]
public class MeleeWeaponData : WeaponData
{
    [Header("Melee Attack Info")]
    public Vector2 collideBoxSize = Vector2.one;
}
