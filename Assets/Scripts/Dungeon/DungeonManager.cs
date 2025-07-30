using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonManager : MonoBehaviour
{
    public int wave;

    [SerializeField]
    private int maxWave;
    private int ememySpawnCount = 5;
    [SerializeField]
    private GameObject portalObject;
    [SerializeField]
    private GameObject[] dungeonFieldObjects;
    [SerializeField]
    private GameObject[] dungeonFields;
    void Start()
    {
        wave++;
        maxWave = Random.Range(0, 5) + 1;
        if (dungeonFieldObjects != null)
        {
            int selectRandomDungeon = Random.Range(0, dungeonFieldObjects.Length);
            Instantiate(dungeonFields[selectRandomDungeon], Vector3.zero, Quaternion.identity, transform);
            Instantiate(dungeonFieldObjects[selectRandomDungeon], Vector3.zero, Quaternion.identity, transform);
        }
        else
        {
            Debug.Log("던전필드가 없습니다");
        }
    }

    void Update()
    {
        WaveLogic();
    }

    private void WaveLogic()
    {
        if (EnemyManager.Instance.GetEnemyListSize() <= 0)
        {
            if (wave == maxWave)
            {
                portalObject.SetActive(true);
            }
            else
            {
                for (int i = 0; i < ememySpawnCount; i++)
                {
                    EnemyManager.eEnemyType randomEnemyType = (EnemyManager.eEnemyType)Random.Range((int)EnemyManager.eEnemyType.eTemp, (int)EnemyManager.eEnemyType.eEnd);
                    EnemyManager.Instance.AddEnemy(randomEnemyType, Vector3.zero);
                }
                wave++;
            }
        }
    }
}
