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

    //�׾����� ȣ���ϴ� �Լ� EX). �׾ ����Ʈ�� ������ ���̴̻´ٴ��� �� 
    virtual protected void DieAtcion()
    {
        Destroy(this);
    }

    //���� ���� �������� �ٸ��� �Ǵ���
    virtual protected void Movement()
    {
    }

    public void HitEnemy(int dmg)
    {
        enemyModel.HitEnemy(dmg);
    }
}
