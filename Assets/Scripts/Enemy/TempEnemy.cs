using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempEnemy : EnemyController
{
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<ResourceController>().ChangeHealth(-100);
//            enemyModel.HitEnemy(100);
        }
    }
}
