using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class PlayerController : BaseController
{
    private Camera camera;


    protected override void Start()
    {
        base.Start();
        camera = Camera.main;

    }


    protected override void HandleAction()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        movementDirection = new Vector2(horizontal, vertical).normalized;

        Vector2 mousePosition = Input.mousePosition;
        Vector2 worldPos = camera.ScreenToWorldPoint(mousePosition);

        lookDirection = (worldPos - (Vector2)transform.position);

        if(lookDirection.magnitude < .9f)
        {
            lookDirection = Vector2.zero;
        }
        else
        {
            lookDirection = lookDirection.normalized;
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
    }

    private void EquipWeapon(int index)
    {
        EquipWeapon(weapons[index]);
    }
}
