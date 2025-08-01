using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCircle : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    EnemyManager.eEnemyType targetEnemyType;
    int bossNum = 0;
    private void Awake()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    public void SetEnemyData(EnemyManager.eEnemyType enemyType)
    {
        targetEnemyType = enemyType;
        Invoke("SpawnEnemy", 1.5f);
    }
    public void SetBossData(int bossNum)
    {
        Invoke("SpawnBoss", 1.5f);
        this.bossNum = bossNum;
    }
    private void SpawnEnemy()
    {
        EnemyManager.Instance.AddEnemy(targetEnemyType, transform.position);
        Destroy(gameObject);
    }

    private void SpawnBoss()
    {
        EnemyManager.Instance.AddBoss(bossNum, transform.position);
        Destroy(gameObject);
    }
}
