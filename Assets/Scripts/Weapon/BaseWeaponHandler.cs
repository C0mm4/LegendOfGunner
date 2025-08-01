using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseWeaponHandler : MonoBehaviour
{
    [SerializeField]
    private float delay = 0.2f;
    public float Delay {  get { return delay; } set { delay = value; } }

    [SerializeField]
    private float power = 1f;
    public float Power { get { return power; } set { power = value; } }

    [SerializeField]
    public float speed = 1f;
    public float Speed {  get { return speed; } set { speed = value; } }

    [SerializeField]
    private float attackRange = 10f;
    [SerializeField]
    public float AttackRange {  get { return attackRange; } set { attackRange = value; } }

    [SerializeField]
    private int currentAmmo;
    public int CurrentAmmo { get { return currentAmmo; } }

    [SerializeField]
    private int maxAmmo;
    [SerializeField]
    public int MaxAmmo { get { return maxAmmo; } }


    public LayerMask target;

    private static readonly int IsAttack = Animator.StringToHash("IsAttack");

    public BaseController Controller {  get; private set; }

    private Animator animator;
    [SerializeField]
    private SpriteRenderer spriteRenderer;

    [SerializeField]
    protected float coolTime = 0f;
    public bool isCooltime = false;
    protected float leftCooltime = 0f;

    protected virtual void Awake()
    {
        Controller = GetComponentInParent<BaseController>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        animator = GetComponentInChildren<Animator>();
    }

    private void Start()
    {
        currentAmmo = maxAmmo;
    }

    public virtual void Attack()
    {
        if (animator != null)
            animator.SetTrigger(IsAttack);
        if(MaxAmmo != -1)
        {
            currentAmmo--;
        }
    }

    public void EquipWeapon()
    {
        currentAmmo = maxAmmo;
    }

    public virtual void Rotate(bool isLeft)
    {
        spriteRenderer.flipY = isLeft;
    }

    public void SetCooltime()
    {
        isCooltime = true;
        leftCooltime = coolTime;
    }

    public void UpdateCooltime(float deltaT)
    {
        leftCooltime -= deltaT;
        if(leftCooltime <= 0f)
        {
            isCooltime = false;
        }
    }
}
