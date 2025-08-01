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
        targetTrans = playerObject.transform;
        enemyModel = statHandler as EnemyModel;
    }

    public virtual void Init()
    {

    }

    protected override void Start()
    {
        base.Start();
    }

    protected override void Update() // base���� ó��
    {
        lookDirection = movementDirection;
        base.Update();
    }
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
        if(playerObject != null ) 
            playerObject.GetComponent<ResourceController>().AddExp(statHandler.Exp);
    }

    //���� ���� �������� �ٸ��� �Ǵ���
    protected virtual void Movement()
    {
        if (targetTrans == null) return;
        movementDirection = (targetTrans.position - transform.position).normalized;
        /*
                Vector3 enemyToPlayerDirection = (playerObject.transform.position - transform.position).normalized;
                base.Movement(enemyToPlayerDirection);
        */
    }

    public virtual void Damaged()
    {
        Debug.Log($"Get Damaged HP : {statHandler.Health}");
        if(view != null)
        {

//            view.SetHpBar((int)enemyModel.Health, (int)enemyModel.Health);
        }
    }
}
