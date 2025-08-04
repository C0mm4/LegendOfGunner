using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatusUIManager : MonoBehaviour
{
    // Start is called before the first frame update
    public TMP_Text HP;
    public TMP_Text Exp;
    public TMP_Text Level;
    public TMP_Text HG_AtkSpd;
    public TMP_Text HG_dmg;
    public TMP_Text HG_double;
    public TMP_Text HG_laser;
    public TMP_Text HG_triple;
    public TMP_Text AR_AtkSpd;
    public TMP_Text AR_AddBullet;
    public TMP_Text AR_granade;
    public TMP_Text AR_laser;
    public TMP_Text AR_CD;


    ResourceController resourceController;
    private AttributeManager attributeManager;

    private void Start()
    {
        resourceController = FindObjectOfType<ResourceController>();
        attributeManager = AttributeManager.Instance;

    }

    private void Update()
    {
        HP.text = $"HP : {Mathf.Round(resourceController.CurrentHealth)}  /  {Mathf.Round(resourceController.MaxHealth)}";
        Exp.text = $"Exp : {resourceController.Exp}  /  {resourceController.RequireExp}";
        Level.text = $"Level : {resourceController.Level}";


        HG_dmg.text = attributeManager.GetAttributeLevelString(AttributeManager.WeaponType.HG, 0);
        HG_AtkSpd.text = attributeManager.GetAttributeLevelString(AttributeManager.WeaponType.HG, 1);
        HG_double.text = attributeManager.GetAttributeLevelString(AttributeManager.WeaponType.HG, 2);
        HG_laser.text = attributeManager.GetAttributeLevelString(AttributeManager.WeaponType.HG, 3);
        HG_triple.text = attributeManager.GetAttributeLevelString(AttributeManager.WeaponType.HG, 4);
        /*
        // AR
        AR_AtkSpd.text = attributeManager.GetAttributeLevelString(WeaponType.AR, 0);
        AR_AddBullet.text = attributeManager.GetAttributeLevelString(WeaponType.AR, 1);
        AR_granade.text = attributeManager.GetAttributeLevelString(WeaponType.AR, 2);
        AR_laser.text = attributeManager.GetAttributeLevelString(WeaponType.AR, 3);
        AR_CD.text = attributeManager.GetAttributeLevelString(WeaponType.AR, 4);
        */
    }
}
