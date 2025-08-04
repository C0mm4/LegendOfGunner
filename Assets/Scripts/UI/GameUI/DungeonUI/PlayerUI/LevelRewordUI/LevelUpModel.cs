using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using UnityEngine;
using UnityEngine.Events;

public class LevelUpModel : MonoBehaviour
{

    [SerializeField]
    public Attribute[] handgun;
    [SerializeField]
    public Attribute[] shotgun;
    [SerializeField]
    public Attribute[] rifle;
    [SerializeField]
    public Attribute[] sniper;

    public Queue<Attribute> handgunQueue = new();
    Queue<Attribute> shotgunQueue = new();
    Queue<Attribute> rifleQueue = new();
    Queue<Attribute> sniperQueue = new();

    Queue<Attribute>[] randomReword;

    int shotgunWeight = 100;
    int rifleWeight = 100;
    int sniperWeight = 100;
    private void Start()
    {
        SetRandomQueue();
    }

    public void SetRandomQueue()
    {

        foreach (var item in Util.Shuffle(handgun))
        {
            if(item.CurrentLevel < item.MaxLevvel)
                handgunQueue.Enqueue(item);
        }
        foreach (var item in Util.Shuffle(shotgun))
        {
            if (item.CurrentLevel < item.MaxLevvel)
                shotgunQueue.Enqueue(item);
        }
        foreach (var item in Util.Shuffle(rifle))
        {
            if (item.CurrentLevel < item.MaxLevvel)
                rifleQueue.Enqueue(item);
        }
        foreach (var item in Util.Shuffle(sniper))
        {
            if (item.CurrentLevel < item.MaxLevvel)
                sniperQueue.Enqueue(item);

        }
    }

    public void SelectReword(int number)
    {
        Attribute target = null;
        switch (number)
        {
            case 0:
                target = handgunQueue.Dequeue();
                break;
            case 1:
                target = randomReword[0].Dequeue();
                break;
            case 2:
                target = randomReword[1].Dequeue();

                break;
        }
        if(target != null)
        {
            target.ApplyAttribute();
        }
        gameObject.SetActive(false);
    }

    public Queue<Attribute>[] SetRandomReword()
    {
        SetRandomQueue();
        randomReword = new Queue<Attribute>[3] { shotgunQueue, rifleQueue, sniperQueue };
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
