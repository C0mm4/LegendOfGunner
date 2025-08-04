using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class BaseWeaponHandler : MonoBehaviour
{
    [SerializeField]
    public WeaponData data;
    public float Delay {  get { return data.Delay; } set { data.Delay = value; } }

    public float Power { get { return data.Power; } set { data.Power = value; } }

    public float Speed {  get { return data.Speed; } set { data.Speed = value; } }

    public float AttackRange {  get { return data.AttackRange; } set { data.AttackRange = value; } }

    public int CurrentAmmo { get { return data.CurrentAmmo; } set { data.CurrentAmmo = value; } }

    public int MaxAmmo { get { return data.MaxAmmo; } set { data.MaxAmmo = value; } }

    public LayerMask target;

    private static readonly int IsAttack = Animator.StringToHash("IsAttack");

    [SerializeField]
    public BaseController Controller {  get; private set; }

    private Animator animator;
    [SerializeField]
    private SpriteRenderer spriteRenderer;

    public Action attackCallback;


    protected virtual void Awake()
    {
        Controller = GetComponentInParent<BaseController>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        animator = GetComponentInChildren<Animator>();
        data = Instantiate(data);
    }

    protected virtual void Start()
    {
        CurrentAmmo = MaxAmmo;
    }

    public virtual void Attack()
    {
        if (animator != null)
            if (animator.runtimeAnimatorController != null)
                animator.SetTrigger(IsAttack);
        if(data.attackSFX != null)
        {
            SoundManager.Instance.PlaySFX(data.attackSFX);
        }
        if(MaxAmmo != -1)
        {
            CurrentAmmo--;
        }
        attackCallback?.Invoke();
    }

    public void EquipWeapon()
    {
        CurrentAmmo = MaxAmmo;
    }

    public Action<bool> rotateCallback;

    public virtual void Rotate(bool isLeft)
    {
        spriteRenderer.flipY = isLeft;
        rotateCallback?.Invoke(isLeft);
    }

    public void SetCooltime()
    {
        data.IsCooltime = true;
        data.LeftCoolTime = data.CoolTime;
    }

    public void UpdateCooltime(float deltaT)
    {
        data.LeftCoolTime -= deltaT;
        if(data.LeftCoolTime <= 0f)
        {
            data.IsCooltime = false;
        }
    }
}
