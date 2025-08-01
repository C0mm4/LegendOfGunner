using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : BaseController
{
    private Camera camera;


    protected override void Start()
    {
        base.Start();
        camera = Camera.main;

        // Set Target Transform Object
        GameObject go = new GameObject();
        go.transform.SetParent(transform);
        targetTrans = go.transform;
    }


    protected override void HandleAction()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        movementDirection = new Vector2(horizontal, vertical).normalized;

        Vector2 mousePosition = Input.mousePosition;
        Vector2 worldPos = camera.ScreenToWorldPoint(mousePosition);

        lookDirection = (worldPos - (Vector2)transform.position);

        if(lookDirection.magnitude < .01f)
        {
            lookDirection = Vector2.zero;
        }
        else
        {
            lookDirection = lookDirection.normalized;
        }

        if (targetTrans != null)
        {
            float radianRotZ = Mathf.Atan2(lookDirection.y, lookDirection.x);
            float rotZ = radianRotZ * Mathf.Rad2Deg;
            bool isLeft = Mathf.Abs(rotZ) > 90f;

            targetTrans.rotation = Quaternion.Euler(0, 0, rotZ);
            targetTrans.localPosition = isLeft ?
                new Vector3(Mathf.Cos(-radianRotZ), Mathf.Sin(radianRotZ)):
                new Vector3(Mathf.Cos(radianRotZ), Mathf.Sin(radianRotZ));

        }

        // For Test Weapon Equip
        if (Input.GetKeyDown(KeyCode.Q))
        {
            EquipWeapon(0);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            EquipWeapon(1);
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            ResourceController resourceController = GetComponent<ResourceController>();
            resourceController.ChangeHealth(-5);

        }
    }

    private void EquipWeapon(int index)
    {
        EquipWeapon(weapons[index]);
    }
}
