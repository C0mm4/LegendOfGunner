using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;



public class EnemyController : MonoBehaviour
{
    [SerializeField]
    protected EnemyView view;
    [SerializeField]
    protected EnemyModel enemyModel;
    private void Update()
    {
        if (enemyModel.status.currentHp <= 0)
        {
            DieAtcion();
        }
        else
        {
            Attack();
            Movement();
        }
    }

    virtual protected void Attack()
    {
    }

    //죽었을때 호출하는 함수 EX). 죽어서 이펙트를 뒤지게 많이뽑는다던지 등 
    virtual protected void DieAtcion()
    {
        Destroy(this);
    }

    //몬스터 마다 움직임이 다르다 판단함
    virtual protected void Movement()
    {
    }

    public void HitEnemy(int dmg)
    {
        enemyModel.HitEnemy(dmg);
    }
}
