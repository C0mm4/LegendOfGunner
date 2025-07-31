using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCircle : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    EnemyManager.eEnemyType targetEnemyType;

    private void Awake()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    public void SetEnemyData(EnemyManager.eEnemyType enemyType)
    {
        targetEnemyType = enemyType;
        Invoke("SpawnEnemy", 1.5f);
    }

    private void SpawnEnemy()
    {
        EnemyManager.Instance.AddEnemy(targetEnemyType, transform.position);
        Destroy(gameObject);
    }
}
