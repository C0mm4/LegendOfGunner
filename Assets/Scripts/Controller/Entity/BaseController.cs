using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseController : MonoBehaviour
{
    protected Rigidbody2D _rigidbody;

    [SerializeField] private SpriteRenderer characterRenderer;
    [SerializeField] protected Transform weaponPivot;

    protected Vector2 movementDirection = Vector2.zero;
    public Vector2 MovementDirection {get { return movementDirection; } }

    protected Vector2 lookDirection = Vector2.zero;
    public Vector2 LookDirection { get { return lookDirection; } }

    protected Vector2 knockback = Vector2.zero;
    private float knockbackDuration = 0.0f;

    [SerializeField]
    private List<BaseWeaponHandler> weaponPref;

    [SerializeField]
    protected List<BaseWeaponHandler> weapons;

    [SerializeField]
    private BaseWeaponHandler currentWeapon;

    [SerializeField]
    private BaseWeaponHandler baseWeapon;

    private float lastAttackTime = 0f;

    private Vector3 weaponPivotPos;
    protected AnimationHandler animationHandler;
    protected StatHandler statHandler;

    [SerializeField] private BaseWeaponHandler weapon;
    protected bool isAttackInput = true;

    protected virtual void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        weaponPivotPos = weaponPivot.localPosition;
        CreateWeapon();
        animationHandler = GetComponent<AnimationHandler>();
        statHandler = GetComponent<StatHandler>();
    }

    protected virtual void CreateWeapon()
    {
        for (int i = 0; i < weaponPref.Count; i++)
        {
            if (weaponPref[i] != null)
            {
                BaseWeaponHandler weapon = Instantiate(weaponPref[i], weaponPivot, false).GetComponent<BaseWeaponHandler>();
                weapon.gameObject.SetActive(false);
                weapons.Add(weapon);

            }
        }
        SetBaseWeapon(weapons[0]);
        EquipWeapon(weapons[0]);
    }

    protected virtual void Start()
    {
        
    }

    protected virtual void Update()
    {
        HandleAction();
        Rotate(lookDirection);
        AttackHandler();
        UpdateCooltime();
    }

    protected virtual void FixedUpdate()
    {
        Movement(movementDirection);
        if(knockbackDuration > 0.0f)
        {
            knockbackDuration -= Time.deltaTime;
        }
    }

    protected virtual void HandleAction()
    {

    }

    protected virtual void UpdateCooltime()
    {
        for (int i = 0; i < weapons.Count; i++)
        {
            if (weapons[i].isCooltime)
            {
                weapons[i].UpdateCooltime(Time.deltaTime);
            }
        }
    }

    private void Movement(Vector2 direction)
    {
        direction = direction * statHandler.Speed;
        if(knockbackDuration > 0.0f)
        {
            direction *= 0.2f;
            direction += knockback;
        }

        _rigidbody.velocity = direction;
    }

    private void Rotate(Vector2 direction)
    {
        float radianRotZ = Mathf.Atan2(direction.y, direction.x);
        float rotZ = radianRotZ * Mathf.Rad2Deg;
        bool isLeft = Mathf.Abs(rotZ) > 90f;

        characterRenderer.flipX = isLeft;

        if(weaponPivot != null)
        {
            weaponPivot.rotation = Quaternion.Euler(0, 0, rotZ);
            weaponPivot.localPosition = isLeft ?
                new Vector3(Mathf.Cos(-radianRotZ), Mathf.Sin(radianRotZ)) * weaponPivotPos.magnitude :
                new Vector3(Mathf.Cos(radianRotZ), Mathf.Sin(radianRotZ)) * weaponPivotPos.magnitude;


            /*weaponPivot.localPosition = isLeft ? 
                new Vector3(-weaponPivotPos.x + Mathf.Cos(radianRotZ), weaponPivotPos.y + Mathf.Sin(radianRotZ), 0) * weaponPivotPos.magnitude 
                : (weaponPivotPos + new Vector3(Mathf.Cos(radianRotZ), Mathf.Sin(radianRotZ))) * weaponPivotPos.magnitude;
            */
            currentWeapon.Rotate(isLeft);
        }
    }

    private void AttackHandler()
    {
        if(lastAttackTime >= currentWeapon.Delay)
        {
            currentWeapon?.Attack();
            lastAttackTime = 0;
            // 현재 무기 탄환 다 쓰면 기본 무기 장착
            // 기본무기는 MaxAmmo -1로 두어 예외처리
            if(currentWeapon?.MaxAmmo != -1 && currentWeapon?.CurrentAmmo <= 0)
            {
                currentWeapon.SetCooltime();
                EquipBaseWeapon();
            }
        }
        else
        {
            lastAttackTime += Time.deltaTime;   
        }
    }


    public void ApplyKnockback(Transform other, float power, float duration)
    {
        knockbackDuration = duration;
        knockback = -(other.position - transform.position).normalized * power;
    }

    protected void EquipWeapon(BaseWeaponHandler weapon)
    {
        if(weapon != this.currentWeapon)
        {
            if (weapon.isCooltime) return;

            if(this.currentWeapon != null)
                this.currentWeapon.gameObject.SetActive(false);
            this.currentWeapon = weapon;
            this.currentWeapon.gameObject.SetActive(true);
            this.currentWeapon.EquipWeapon();
            // Reset Attack Delay Time
            lastAttackTime = 99f;
        }
    }

    protected void SetBaseWeapon(BaseWeaponHandler weapon)
    {
        baseWeapon = weapon;
    }

    private void EquipBaseWeapon()
    {
        EquipWeapon(baseWeapon);
    }
}
