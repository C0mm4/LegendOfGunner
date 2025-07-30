using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseController : MonoBehaviour
{
    protected Rigidbody2D _rigidbody;

    [SerializeField] private SpriteRenderer characterRenderer;
    [SerializeField] private Transform weaponPivot;

    protected Vector2 movementDirection = Vector2.zero;
    public Vector2 MovementDirection {get { return movementDirection; } }

    protected Vector2 lookDirection = Vector2.zero;
    public Vector2 LookDirection { get { return lookDirection; } }

    protected Vector2 knockback = Vector2.zero;
    private float knockbackDuration = 0.0f;

    [SerializeField]
    private BaseWeaponHandler weapon;

    private float lastAttackTime = 0f;

    private Vector3 weaponPivotPos;

    protected virtual void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        weaponPivotPos = weaponPivot.localPosition;
    }

    protected virtual void Start()
    {
        
    }

    protected virtual void Update()
    {
        HandleAction();
        Rotate(lookDirection);
        AttackHandler();
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

    private void Movement(Vector2 direction)
    {
        direction = direction * 5;
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
            weapon.Rotate(isLeft);
        }
    }

    private void AttackHandler()
    {
        if(lastAttackTime >= weapon.Delay)
        {
            weapon?.Attack();
            lastAttackTime = 0;
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
        this.weapon.gameObject.SetActive(false);
        this.weapon = weapon;
        this.weapon.gameObject.SetActive(true);
    }
}
