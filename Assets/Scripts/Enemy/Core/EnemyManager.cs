using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class EnemyManager : MonoSingleton<EnemyManager>
{
    public enum eEnemyType
    {
        eAlarmbot,
        eHG,
        eAR,
        eSG,
        eEnd,
    }
    [SerializeField]
    private EnemyFactory enemyFactory;

    [SerializeField]
    private List<GameObject> enemyList = new();
    public List<GameObject> EnemyList { get => enemyList; }

    public void Start()
    {
    }

    public GameObject GetEnemyObj(eEnemyType type)
    {
        GameObject obj = null;
        switch (type)
        {
            case eEnemyType.eAlarmbot:
                obj = enemyList[0];
                break;
            case eEnemyType.eHG:
                obj = enemyList[1];
                break;
            case eEnemyType.eAR:
                obj = enemyList[2];
                break;
            case eEnemyType.eSG:
                obj = enemyList[3];
                break;
            case eEnemyType.eSR:
                obj = enemyList[4];
                break;
        }
        return obj;
    }

    public void AddEnemy(eEnemyType idx, Vector3 spawnPos)
    {
        if (enemyFactory == null)
        {
            Debug.Log("Null EnemyFactory");
            enemyFactory = GameObject.FindObjectOfType<EnemyFactory>();
            if (enemyFactory == null)
            {
                Debug.Log("Still Null EnemyFactory");

                return;

            }
        }
        var obj = enemyFactory.AddEnemy(idx, spawnPos);
        if (obj != null)
        {
            enemyList.Add(obj);
        }
    }
    public void AddBoss(int bossNum, Vector3 spawnPos)
    {
        if (enemyFactory == null)
        {
            Debug.Log("Null EnemyFactory");
            return;
        }
        var obj = enemyFactory.AddBoss(bossNum, spawnPos);
        if (obj != null)
        {
            Debug.Log("test2");
            enemyList.Add(obj);
        }
    }
    public void RemoveObject(GameObject obj)
    {
        enemyList.Remove(obj);
    }
    public int GetEnemyListSize()
    {
        return enemyList.Count;
    }
}
