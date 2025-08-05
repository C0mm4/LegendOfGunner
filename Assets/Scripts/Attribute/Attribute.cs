using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Attribute", menuName = "Attribute/new Attribute")]
public class Attribute : ScriptableObject
{
    [SerializeField]
    private string name;
    public string GetName {  get { return name; } }

    [SerializeField] 
    private string description;
    public string GetDesc {  get { return description; } }

    [SerializeField]
    private int maxLevel = 1;
    public int MaxLevvel {  get { return maxLevel; } }

    [SerializeField]
    private int currentLevel = 0;
    public int CurrentLevel {  get { return currentLevel; } set { currentLevel = value; } }
    
    public enum AttributeType
    {
        Status, ChangeBullet, AddAction
    }

    [SerializeField]
    private AttributeType attributeType;
    public AttributeType GetAttributeType {  get { return attributeType; } }

    public enum WeaponType
    {
        HG, AR, SG, SR
    }

    [SerializeField]
    private float IncreaseDMG;

    [SerializeField]
    private float DecreaseDelay;

    [SerializeField]
    private int IncreaseBullet;

    [SerializeField]
    private GameObject ReplaceBulletPref;

    [SerializeField]
    private float DecreaseCooltime;

    [SerializeField]
    private int IncreasePiercingEnemmy;

    [SerializeField]
    private float IncreaseCriticalP;

    [SerializeField]
    private WeaponType weaponType;
    public WeaponType GetWeaponType { get { return weaponType; } }

    protected BaseWeaponHandler applyTargetWeapon;

    public virtual void ApplyAttribute()
    {
        currentLevel++;
        applyTargetWeapon = SetTargetWeapon();
        switch (attributeType)
        {
            case AttributeType.Status:
                AddStatus();
                break;
            case AttributeType.ChangeBullet:
                ChangeBullet();
                break;
            case AttributeType.AddAction:
                AddAction();
                break;
        }
    }


    private BaseWeaponHandler SetTargetWeapon()
    {
        switch (weaponType)
        {
            case WeaponType.HG:
                return GameManager.PlayerInstance.GetWeapon(0);
            case WeaponType.AR:
                return GameManager.PlayerInstance.GetWeapon(1);
            case WeaponType.SG:
                return GameManager.PlayerInstance.GetWeapon(2);
            case WeaponType.SR:
                return GameManager.PlayerInstance.GetWeapon(3);

        }
        return null;
    }

    protected virtual void AddStatus() 
    {
        RangeWeaponData data = applyTargetWeapon.data as RangeWeaponData;

        data.Power += IncreaseDMG;
        data.Delay -= DecreaseDelay;
        data.MaxAmmo += IncreaseBullet;
        data.CoolTime -= DecreaseCooltime;
        data.PiercingEnemyCount += IncreasePiercingEnemmy;
        data.CriticalPercentage += IncreaseCriticalP;

    }
    protected virtual void ChangeBullet() 
    {
        if(ReplaceBulletPref == null) return;

        RangeWeaponData data = applyTargetWeapon.data as RangeWeaponData;
        applyTargetWeapon.GetComponent<RangeWeaponHandler>()?.ChangeBullet(ReplaceBulletPref);
        data.PiercingEnemyCount += 99;
    }

    protected virtual void AddAction() { }
}
