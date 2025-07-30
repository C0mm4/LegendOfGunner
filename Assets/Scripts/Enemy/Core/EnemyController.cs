using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;



public class EnemyController : BaseController
{
    [SerializeField]
    protected EnemyView view;
    [SerializeField]
    protected EnemyModel enemyModel;

    private GameObject playerObject;


    protected override void Awake()
    {
        base.Awake();
        playerObject = GameObject.FindObjectOfType<PlayerController>().gameObject;
    }
/*
    protected override void Start()
    {
        playerObject = GameObject.FindObjectOfType<PlayerController>().gameObject;
        _rigidbody = GetComponent<Rigidbody2D>();
        statHandler = enemyModel.GetStatus();
    }
*/
/*
    protected override void Update() // base���� ó��
    {
        if (enemyModel.status.Health <= 0)
        {
            DieAtcion();
        }
        else
        {
            Movement();
            Attack();
        }
    }
*/
    protected override void FixedUpdate()
    {
        base.FixedUpdate(); 
        Movement();
    }
    virtual protected void Attack()
    {
    }

    //�׾����� ȣ���ϴ� �Լ� EX). �׾ ����Ʈ�� ������ ���̴̻´ٴ��� �� 
    protected virtual void OnDisable() // base���� ó��
    {
        EnemyManager.Instance.RemoveObject(this.gameObject);
        Destroy(this.gameObject);
    }

    //���� ���� �������� �ٸ��� �Ǵ���
    protected virtual void Movement()
    {
        movementDirection = (playerObject.transform.position - transform.position).normalized;
/*
        Vector3 enemyToPlayerDirection = (playerObject.transform.position - transform.position).normalized;
        base.Movement(enemyToPlayerDirection);
*/
    }
/*
    public void HitEnemy(int dmg)
    {
        enemyModel.HitEnemy(dmg);
    }*/
}
