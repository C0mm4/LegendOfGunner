using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class MeleeWeaponHandler : BaseWeaponHandler
{
    [Header("Melee Attack Info")]
    public Vector2 collideBoxSize = Vector2.one;


    public override void Attack()
    {
        base.Attack();
        RaycastHit2D hit = Physics2D.BoxCast(transform.position + (Vector3)Controller.LookDirection * collideBoxSize.x,
            collideBoxSize, 0, Vector2.zero, target);

        if (hit.collider != null)
        {
            Debug.Log("Melee Attack");
            // Add Hit Action
            /*
            ResourceController resource = hit.collider.GetComponent<ResourceController>();
            if (resource != null)
            {
                resource.ChangeHealth(-Power);
                if (IsOnKnockBack)
                {
                    BaseController baseController = hit.collider.GetComponent<BaseController>();
                    if (baseController != null)
                    {
                        baseController.ApplyKnockback(transform, KnockBackPower, KnockBackTime);
                    }
                }
            }*/
        }
    }

    public override void Rotate(bool isLeft)
    {
        if (isLeft)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
    }

}
