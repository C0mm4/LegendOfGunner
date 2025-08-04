using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttributeManager : MonoSingleton<AttributeManager>
{
    [SerializeField]
    public List<Attribute> _HandGunAttributes;

    [SerializeField]
    public List<Attribute> _RifleAttributes;
    [SerializeField]
    public List<Attribute> _ShotgunAttributes;
    [SerializeField]
    public List<Attribute> _SniperAttributes;


    public void Init()
    {
        foreach (var item in _HandGunAttributes)
        {
            item.CurrentLevel = 0;
        }
        foreach (var item in _RifleAttributes)
        {
            item.CurrentLevel = 0;
        }
        foreach (var item in _ShotgunAttributes)
        {
            item.CurrentLevel = 0;
        }
        foreach (var item in _SniperAttributes)
        {
            item.CurrentLevel = 0;
        }
    }

    public void ShuffleAttributes()
    {
/*        _HandGunAttributes.Shuffle();
        _RifleAttributes.Shuffle();
        _ShotgunAttributes.Shuffle();
        _SniperAttributes.Shuffle();*/
    }

    public List<Attribute> Get3Attributes()
    {
        List<Attribute> list = new List<Attribute>();

        // Select Weapon Attributes

        // Select 2 Random Weapon Attributes

        return list;
    }
}
