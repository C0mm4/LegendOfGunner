using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using UnityEngine;
using UnityEngine.Events;
using static UnityEditor.Progress;

public class LevelUpModel : MonoBehaviour
{
    List<Attribute>[] randomReword;

    int shotgunWeight = 100;
    int rifleWeight = 100;
    int sniperWeight = 100;

    AttributeManager manager;


    private void Start()
    {
        manager = AttributeManager.Instance;
        manager.Init();

    }

    public void SetRandomQueue()
    {
        if(manager == null)
        {
            manager = AttributeManager.Instance;
            manager.Init();
        }
        manager.ShuffleAttributes();
    }

    public void SelectReword(int number, Attribute target)
    {
        if(target != null)
        {
            target.ApplyAttribute();
        }
        gameObject.SetActive(false);
    }

    public List<Attribute>[] SetRandomReword()
    {
        SetRandomQueue();
        randomReword = new List<Attribute>[3] { manager._RifleAttributes, manager._ShotgunAttributes, manager._SniperAttributes };
        
        randomReword = Util.RandomReturn2(shotgunWeight, rifleWeight, sniperWeight, randomReword);
        return randomReword;
    }

    /*
    public List<sCharacteristic>[] SetRandomReword()
    {
        if (shotguns == null)
            Init();
        randomReword = new List<sCharacteristic>[3] { shotguns, rifles, snipers };
        Debug.Log("2¹ø");

        if (shotguns.Count == 0 && rifles.Count == 0 && snipers.Count != 0)
        {
            randomReword = new List<sCharacteristic>[1] { snipers };
        }
        else if (shotguns.Count == 0 && snipers.Count == 0 && rifles.Count != 0)
        {
            randomReword = new List<sCharacteristic>[1] { rifles };
        }
        else if (snipers.Count == 0 && rifles.Count == 0 && shotguns.Count != 0)
        {
            randomReword = new List<sCharacteristic>[1] { shotguns };
        }
        else if (snipers.Count == 0 && rifles.Count == 0 && shotguns.Count == 0)
        {
            randomReword = null;
        }
        else
        {
            randomReword = Util.RandomReturn2(
                shotguns.Count == 0 ? 0 : shotgunWeight,
                rifles.Count == 0 ? 0 : rifleWeight,
                snipers.Count == 0 ? 0 : sniperWeight,
                randomReword);
        }

        return randomReword;
    }
*/
}
