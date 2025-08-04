using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using UnityEngine;
using UnityEngine.Events;

public class LevelUpModel : MonoBehaviour
{
    [Serializable]
    public struct sCharacteristic
    {
        public string name;
        public string info;
        [Header("수치")]
        public float levels;

        [Header("이 함수가 몇번 실행가능한지")]
        public int count;
        [SerializeField]
        public UnityEvent callback;

        public void SetCount(int _count)
        {
            count = _count;
        }
    }
    [SerializeField]
    public sCharacteristic[] handgun;
    [SerializeField]
    public sCharacteristic[] shotgun;
    [SerializeField]
    public sCharacteristic[] rifle;
    [SerializeField]
    public sCharacteristic[] sniper;

    public List<sCharacteristic> handguns;
    List<sCharacteristic> shotguns;
    List<sCharacteristic> rifles;
    List<sCharacteristic> snipers;

    List<sCharacteristic>[] randomReword;

    int shotgunWeight = 100;
    int rifleWeight = 100;
    int sniperWeight = 100;
    private void Start()
    {

    }

    public void Init()
    {
        handguns = new List<sCharacteristic>();
        shotguns = new List<sCharacteristic>();
        rifles = new List<sCharacteristic>();
        snipers = new List<sCharacteristic>();

        foreach (var item in Util.Shuffle(handgun))
        {
            handguns.Add(item);
        }
        foreach (var item in Util.Shuffle(shotgun))
        {
            shotguns.Add(item);
        }
        foreach (var item in Util.Shuffle(rifle))
        {
            rifles.Add(item);
        }
        foreach (var item in Util.Shuffle(sniper))
        {
            snipers.Add(item);
        }
    }

    public void SelectReword(int number)
    {
        switch (number)
        {
            case 0:
                handguns[0].callback.Invoke();
                if (handguns[0].count <= 0)
                {
                    handguns.Remove(handguns[0]);
                }
                else
                {
                    handguns = Util.Shuffle(handguns.ToArray()).ToList<sCharacteristic>();
                }
                break;
            case 1:
                randomReword[0][0].callback.Invoke();
                randomReword[0].Remove(randomReword[0][0]);
                break;
            case 2:
                randomReword[1][0].callback.Invoke();
                randomReword[1].Remove(randomReword[1][0]);
                break;
        }
        gameObject.SetActive(false);
    }

    public List<sCharacteristic>[] SetRandomReword()
    {
        if (shotguns == null)
            Init();
        randomReword = new List<sCharacteristic>[3] { shotguns, rifles, snipers };
        Debug.Log("2번");

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

}
