using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1Controller : EnemyController
{
    protected override void Start()
    {
        base.Start();
    }
    public override void Init()
    {
        base.Init();
        view.SetActiveUI(enemyModel.name);
        InvokeRepeating("spawnEnemy", 1, 5);
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        CancelInvoke("spawnEnemy");
        view.DeActiveUI();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }

    public override void Damaged()
    {
        base.Damaged();
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
    void spawnEnemy()
    {
        for (int i = 0; i < 5; i++)
            EnemyManager.Instance.AddEnemy(EnemyManager.eEnemyType.eTemp, Vector3.zero);
    }
}
