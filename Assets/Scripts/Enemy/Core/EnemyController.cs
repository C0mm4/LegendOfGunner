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

    public virtual void Init()
    {

    }

    protected override void Start()
    {
        base.Start();
    }

    protected override void Update() // base에서 처리
    {
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

    //죽었을때 호출하는 함수 EX). 죽어서 이펙트를 뒤지게 많이뽑는다던지 등 
    protected virtual void OnDisable() // base에서 처리
    {
        EnemyManager.Instance.RemoveObject(this.gameObject);
    }

    //몬스터 마다 움직임이 다르다 판단함
    protected virtual void Movement()
    {
        movementDirection = (playerObject.transform.position - transform.position).normalized;
        /*
                Vector3 enemyToPlayerDirection = (playerObject.transform.position - transform.position).normalized;
                base.Movement(enemyToPlayerDirection);
        */
    }

    public virtual void Damaged()
    {
    }
}
