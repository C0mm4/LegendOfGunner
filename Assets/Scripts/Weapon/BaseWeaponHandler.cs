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

    private int currentAmmo;
    public int CurrentAmmo { get { return currentAmmo; } }

    [SerializeField]
    private int maxAmmo;
    [SerializeField]
    public int MaxAmmo { get { return maxAmmo; } }


    public LayerMask target;

    private static readonly int IsAttack = Animator.StringToHash("IsAttack");
    private static readonly int IsReload = Animator.StringToHash("IsReload");

    public BaseController Controller {  get; private set; }

    private Animator animator;
    private SpriteRenderer spriteRenderer;

    protected virtual void Awake()
    {
        Controller = GetComponentInParent<BaseController>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    private void Start()
    {
        currentAmmo = maxAmmo;
    }

    public virtual void Attack()
    {
        currentAmmo--;
        if(currentAmmo <= 0)
        {
            UnequipWeapon();
        }
    }

    public virtual void Rotate(bool isLeft)
    {
        spriteRenderer.flipY = isLeft;
    }

    public void EquipWeapon()
    {

    }

    public void UnequipWeapon()
    {

    }
}
