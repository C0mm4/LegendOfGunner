using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponData : ScriptableObject
{
    [SerializeField]
    private float delay = 0.2f;
    public float Delay { get { return delay; } set { delay = value; } }

    [SerializeField]
    private float power = 1f;
    public float Power { get { return power; } set { power = value; } }

    [SerializeField]
    public float speed = 1f;
    public float Speed { get { return speed; } set { speed = value; } }

    [SerializeField]
    private float attackRange = 10f;
    [SerializeField]
    public float AttackRange { get { return attackRange; } set { attackRange = value; } }

    [SerializeField]
    private int currentAmmo;
    public int CurrentAmmo { get { return currentAmmo; } set { currentAmmo = value; } }

    [SerializeField]
    private int maxAmmo;
    [SerializeField]
    public int MaxAmmo { get { return maxAmmo; } set { maxAmmo = value; }  }

    [SerializeField]
    private float coolTime;
    public float CoolTime { get { return coolTime; } set { coolTime = value; } }

    private float leftCoolTime;
    public float LeftCoolTime { get {return leftCoolTime; } set { leftCoolTime = value; } }

    private bool isCooltime = false;
    public bool IsCooltime { get { return isCooltime; } set { isCooltime = value; } }

    [SerializeField]
    public AudioClip attackSFX;
    
}
