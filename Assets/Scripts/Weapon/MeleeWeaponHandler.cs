using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class MeleeWeaponHandler : BaseWeaponHandler
{
    MeleeWeaponData meleeData;

    private void Start()
    {
        meleeData = data as MeleeWeaponData;
    }

    public override void Attack()
    {
        base.Attack();
        RaycastHit2D hit = Physics2D.BoxCast(transform.position + (Vector3)Controller.LookDirection * meleeData.collideBoxSize.x,
            meleeData.collideBoxSize, 0, Vector2.zero, 0f, target);

        if (hit.collider != null)
        {
            Debug.Log("Melee Attack");
            ResourceController resource = hit.collider.GetComponent<ResourceController>();
            if (resource != null)
            {
                resource.ChangeHealth(-Power);
/*                if (IsOnKnockBack)
                {
                    BaseController baseController = hit.collider.GetComponent<BaseController>();
                    if (baseController != null)
                    {
                        baseController.ApplyKnockback(transform, KnockBackPower, KnockBackTime);
                    }
                }*/
            }
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
