using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "HGAttribute", menuName = "Attribute/new HG Attribute")]
public class HandgunAttribute : Attribute
{
    protected override void AddAction()
    {
        base.AddAction();
        applyTargetWeapon.transform.localPosition = new Vector3(-0.1f, 0.1f);
        GameObject additionalWeapon = Instantiate(applyTargetWeapon.gameObject, applyTargetWeapon.transform);
        additionalWeapon.transform.localPosition = new Vector3(0, -0.2f, 0);
        var addWeapon = additionalWeapon.AddComponent<AdditionalWeapon>();
        addWeapon.SetBaseWeapon(applyTargetWeapon);
    }
}
