using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempEnemy : EnemyController
{
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
        Debug.Log("1");
        if (Input.GetKeyDown(KeyCode.Space))
        {
            enemyModel.HitEnemy(100);
        }
    }
}
