using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    [SerializeField]
    private LayerMask levelLayer;

    private RangeWeaponHandler weaponHandler;

    private float currentDuration;
    private Vector2 direction;
    private bool isReady;
    private Transform pivot;

    private Rigidbody2D body;
    private SpriteRenderer spriteRenderer;

    public bool fxOnDestroy = true;


    ProjectileManager projectileManager;

    private void Awake()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        body = GetComponent<Rigidbody2D>();
        pivot = transform.GetChild(0);
    }

    private void Update()
    {
        if (!isReady)
        {
            return;
        }

        currentDuration += Time.deltaTime;

        if (currentDuration > weaponHandler.Duration)
        {
            DestroyProjectile(transform.position, false);
        }

        body.velocity = direction * weaponHandler.Speed;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (levelLayer.value == (levelLayer.value | (1 << collision.gameObject.layer)))
        {
            DestroyProjectile(collision.ClosestPoint(transform.position) - direction * .2f, fxOnDestroy);

        }
        else if (weaponHandler.target.value == (weaponHandler.target.value | (1 << collision.gameObject.layer)))
        {
            // Add Target Collision Event
            ResourceController resource = collision.GetComponent<ResourceController>();
            if (resource != null)
            {
                resource.ChangeHealth(-weaponHandler.Power);
                // ³Ë¹é?
/*                if (weaponHandler.IsOnKnockBack)
                {
                    BaseController baseCon = collision.GetComponent<BaseController>();

                    if (baseCon != null)
                    {
                        baseCon.ApplyKnockback(transform, weaponHandler.KnockBackPower, weaponHandler.KnockBackTime);
                    }
                }*/
            }
            collision.GetComponent<EnemyController>()?.Damaged();

            Debug.Log("Collision!");
            DestroyProjectile(collision.ClosestPoint(transform.position), fxOnDestroy);
        }
    }

    public void Init(Vector2 dir, RangeWeaponHandler weapon, ProjectileManager manager)
    {
        direction = dir;
        weaponHandler = weapon;
        currentDuration = 0;
        transform.localScale = Vector3.one * weaponHandler.BulletSize;
        spriteRenderer.color = weaponHandler.ProjectileColor;
        projectileManager = manager;

        transform.right = this.direction;

        if (direction.x < 0)
        {
            pivot.localRotation = Quaternion.Euler(180, 0, 0);
        }
        else
        {
            pivot.localRotation = Quaternion.Euler(0, 0, 0);
        }

        isReady = true;
    }

    public void DestroyProjectile(Vector3 position, bool createFX)
    {
        if (createFX)
        {
            projectileManager.CreateImpactParticle(position, weaponHandler);
        }
        Destroy(this.gameObject);
    }
}

