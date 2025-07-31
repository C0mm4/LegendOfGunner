using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoSingleton<EnemyManager>
{
    public enum eEnemyType
    {
        eTemp,
        eEnd,
    }
    [SerializeField]
    private EnemyFactory enemyFactory;

    [SerializeField]
    private List<GameObject> enemyList = new();

    public void Start()
    {
    }
    public void AddEnemy(eEnemyType idx, Vector3 spawnPos)
    {
        if (enemyFactory == null)
        {
            Debug.Log("Null EnemyFactory");
            return;
        }
        var obj = enemyFactory.AddEnemy(idx, spawnPos);
        if (obj != null)
        {
            enemyList.Add(obj);
        }
    }
    public void AddBoss(int bossNum, Vector3 spawnPos)
    {
        var obj = enemyFactory.AddBoss(bossNum, spawnPos);
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
