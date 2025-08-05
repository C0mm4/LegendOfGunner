using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static EnemyManager;

public class EnemyFactory : MonoBehaviour
{
    [SerializeField]
    private GameObject tempObject;
    [SerializeField]
    private GameObject boss1Object;
    public GameObject AddEnemy(EnemyManager.eEnemyType enemyType, Vector3 spawnPos)
    {
        GameObject obj = null;

        obj = Instantiate(EnemyManager.Instance.GetEnemyObj(enemyType), spawnPos, Quaternion.identity);
        obj.GetComponent<EnemyController>().Init();

        return obj;
    }

    public GameObject AddBoss(int bossNumber, Vector3 spawnPos)
    {
        GameObject obj = null;

        switch (bossNumber)
        {
            case 1:
                obj = Instantiate(boss1Object, spawnPos, Quaternion.identity);
//                obj.GetComponent<EnemyModel>().SettingStatus(3, 1, 1, "TaewoongTestBoss");
                obj.GetComponent<EnemyController>().Init();
                break;
        }

        return obj;
    }
}
