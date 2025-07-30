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
    private List<GameObject> enemyList;

    public void Start()
    {
        enemyList = new List<GameObject>();
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
    public void RemoveObject(GameObject obj)
    {
        enemyList.Remove(obj);
    }
    public int GetEnemyListSize()
    {
        return enemyList.Count;
    }
}
