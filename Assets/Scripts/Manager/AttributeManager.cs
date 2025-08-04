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

    protected override void Awake()
    {
        base.Awake();
        Init();
    }

    int shotgunWeight = 100;
    int rifleWeight = 100;
    int sniperWeight = 100;

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
        shotgunWeight = 100;
        rifleWeight = 100;
        sniperWeight = 100;
    }

    public void ShuffleAttributes()
    {
        _HandGunAttributes.Shuffle();
        _RifleAttributes.Shuffle();
        _ShotgunAttributes.Shuffle();
        _SniperAttributes.Shuffle();
    }

    public List<Attribute> Get3Attributes()
    {
        ShuffleAttributes();
        List<Attribute> list = new List<Attribute>();

        // Select Weapon Attributes
        for(int i = 0; i < _HandGunAttributes.Count; i++)
        {
            if (_HandGunAttributes[i].CurrentLevel < _HandGunAttributes[i].MaxLevvel)
            {
                list.Add(_HandGunAttributes[i]);
                break;
            }
        }
        // Select 2 Random Weapon Attributes
        var randomReword = new List<Attribute>[3] { _RifleAttributes, _ShotgunAttributes, _SniperAttributes };
        randomReword = Util.RandomReturn2(shotgunWeight, rifleWeight, sniperWeight, randomReword);
        for(int i = 0; i < 2; i++)
        {
            for(int j = 0; j < randomReword[i].Count; j++)
            {
                if (randomReword[i][j].CurrentLevel < randomReword[i][j].MaxLevvel)
                {
                    list.Add(randomReword[i][j]);
                    break;
                }
            }
        }

        return list;
    }
}
