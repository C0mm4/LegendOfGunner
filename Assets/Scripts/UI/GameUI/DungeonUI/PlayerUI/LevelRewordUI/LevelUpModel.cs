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


    AttributeManager manager;


    private void Start()
    {
        manager = AttributeManager.Instance;
        manager.Init();

    }


    public void SelectReword(int number, Attribute target)
    {
        if(target != null)
        {
            target.ApplyAttribute();
        }
        gameObject.SetActive(false);
    }

    public List<Attribute> SetRandomReword()
    {
        return AttributeManager.Instance.Get3Attributes();
        
    }
}
