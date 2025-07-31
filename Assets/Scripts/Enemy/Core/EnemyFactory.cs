using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static EnemyManager;

public class EnemyFactory : MonoBehaviour
{
    [SerializeField]
    private GameObject tempObject;
    public GameObject AddEnemy(EnemyManager.eEnemyType enemyType, Vector3 spawnPos)
    {
        GameObject obj = null;

        switch (enemyType)
        {
            case EnemyManager.eEnemyType.eTemp:
                obj = Instantiate(tempObject, spawnPos, Quaternion.identity);
                obj.GetComponent<EnemyModel>().SettingStatus(1, 1, 1);
                break;
        }

        return obj;
    }
}
