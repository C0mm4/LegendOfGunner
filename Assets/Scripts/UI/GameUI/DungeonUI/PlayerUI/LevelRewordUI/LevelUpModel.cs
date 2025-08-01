using System;
using System.Collections;
using System.Collections.Generic;
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

    public Queue<sCharacteristic> handgunQueue;
    Queue<sCharacteristic> shotgunQueue;
    Queue<sCharacteristic> rifleQueue;
    Queue<sCharacteristic> sniperQueue;

    Queue<sCharacteristic>[] randomReword;

    int shotgunWeight = 100;
    int rifleWeight = 100;
    int sniperWeight = 100;
    private void Start()
    {
        handgunQueue = new Queue<sCharacteristic>();
        shotgunQueue = new Queue<sCharacteristic>();
        rifleQueue = new Queue<sCharacteristic>();
        sniperQueue = new Queue<sCharacteristic>();

        foreach (var item in Util.Shuffle(handgun))
        {
            handgunQueue.Enqueue(item);
        }
        foreach (var item in Util.Shuffle(shotgun))
        {
            shotgunQueue.Enqueue(item);
        }
        foreach (var item in Util.Shuffle(rifle))
        {
            rifleQueue.Enqueue(item);
        }
        foreach (var item in Util.Shuffle(sniper))
        {
            sniperQueue.Enqueue(item);
        }
    }

    public void SelectReword(int number)
    {
        switch (number)
        {
            case 0:
                handgunQueue.Dequeue().callback.Invoke();
                break;
            case 1:
                randomReword[0].Dequeue().callback.Invoke();
                break;
            case 2:
                randomReword[1].Dequeue().callback.Invoke();
                break;
        }
        gameObject.SetActive(false);
    }

    public Queue<sCharacteristic>[] SetRandomReword()
    {
        randomReword = new Queue<sCharacteristic>[3] { shotgunQueue, rifleQueue, sniperQueue };
        randomReword = Util.RandomReturn2(shotgunWeight, rifleWeight, sniperWeight, randomReword);
        return randomReword;
    }

}
