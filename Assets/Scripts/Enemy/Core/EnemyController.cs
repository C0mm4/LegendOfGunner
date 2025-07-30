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
    public void Update()
    {
        Debug.Log("2");

        if (enemyModel.status.currentHp <= 0)
        {
            Debug.Log("3");

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
        EnemyManager.Instance.RemoveObject(this.gameObject);
        Destroy(this.gameObject);
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
