using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1Controller : EnemyController
{
    bool isAttack = false;
    protected override void Start()
    {
        base.Start();
    }
    public override void Init()
    {
        base.Init();
        view.SetActiveUI(enemyModel.name, (int)enemyModel.Health, (int)enemyModel.MaxHealth);
        InvokeRepeating("SpawnEnemyTriger", 1, 5);
    }
    void SpawnEnemyTriger()
    {
        view.AttackAnimation(1);
    }
    protected override void OnDisable()
    {
        base.OnDisable();
        view.DeActiveUI();
    }

    // Update is called once per frame
    protected override void Update()
    {
    }

    public override void Damaged()
    {
        base.Damaged();
        view.HitAnimaion();
        view.SetHpBar((int)enemyModel.MaxHealth, (int)enemyModel.Health);
    }
    public override void Death()
    {
        base.Death();
        int len = EnemyManager.Instance.GetEnemyListSize();
        for (int i = 0; i < len; i++)
        {
            EnemyManager.Instance.EnemyList[0].GetComponent<EnemyController>().Death();
        }
    }
    protected override void Movement()
    {

    }
    public void spawnEnemy()
    {
        for (int i = 0; i < 5; i++)
            EnemyManager.Instance.AddEnemy(EnemyManager.eEnemyType.eTemp, Vector3.zero);
    }

}
