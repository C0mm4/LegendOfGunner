using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HPbar : MonoBehaviour
{
    public GameObject hpBar;
    Transform hpBarrect;

    public int maxHP = 10;
    public int HP = 5;
    public int nowHP;

    private void Start()
    {
        hpBarrect = GetComponent<Transform>();
    }
    private void Update()
    {
        nowHP = maxHP - HP;
        float persent = (float)nowHP / (float)maxHP;

        if (nowHP > 0)
        {
            hpBarrect.localScale = new Vector3(persent, 1, 1);
        }
    }
}
