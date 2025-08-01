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
        Debug.Log("tq");
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }

    public override void Damaged()
    {
        view.SetHpBar(10, (int)enemyModel.Health);
    }

    void spawnEnemy()
    {
        for (int i = 0; i < 5; i++)
            EnemyManager.Instance.AddEnemy(EnemyManager.eEnemyType.eTemp, Vector3.zero);
    }
}
