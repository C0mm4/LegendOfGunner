using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonManager : MonoBehaviour
{
    public int wave;
    bool isClear;
    [SerializeField]
    private int maxWave;
    private int ememySpawnCount = 5;
    [SerializeField]
    private GameObject portalObject;
    [SerializeField]
    private GameObject[] dungeonFieldObjects;
    [SerializeField]
    private GameObject[] dungeonFields;

    private GameObject prevDungeonFieldObj;
    private GameObject prevDungoneWallObj;

    void Start()
    {
        StartDungeon();
    }

    void Update()
    {
        if (isClear == false)
        {
            CheckClear();
        }
    }

    public void StartDungeon()
    {
        wave++;
        isClear = false;
        maxWave = Random.Range(3, 6);
        if (dungeonFieldObjects != null)
        {
            if (prevDungeonFieldObj != null)
            {
                Destroy(prevDungeonFieldObj);
                Destroy(prevDungoneWallObj);
            }

            if(maxWave == wave)
            {
                // 보스 웨이브 시 보스 방에서 선택

            }
            else
            {
                int selectRandomDungeon = Random.Range(0, dungeonFieldObjects.Length);
                prevDungeonFieldObj = Instantiate(dungeonFields[selectRandomDungeon], Vector3.zero, Quaternion.identity, transform);
                prevDungoneWallObj = Instantiate(dungeonFieldObjects[selectRandomDungeon], Vector3.zero, Quaternion.identity, transform);
            }
            portalObject.SetActive(false);

            CreateWave();
        }
        else
        {
            Debug.Log("던전필드가 없습니다");
        }
    }

    private void WaveLogic()
    {
        if (EnemyManager.Instance.GetEnemyListSize() <= 0)
        {
            if (wave == maxWave)
            {
                isClear = true;
                portalObject.SetActive(true);
            }
            else
            {
                for (int i = 0; i < ememySpawnCount; i++)
                {
                    StartCoroutine(SpawnEnemy(new Vector2(0, 0)));
                    EnemyManager.eEnemyType randomEnemyType = (EnemyManager.eEnemyType)Random.Range((int)EnemyManager.eEnemyType.eTemp, (int)EnemyManager.eEnemyType.eEnd);
                    EnemyManager.Instance.AddEnemy(randomEnemyType, Vector3.zero);
                }
                wave++;
            }
        }
    }

    private void CreateWave()
    {
        for(int i = 0; i < ememySpawnCount; i++)
        {
            StartCoroutine(SpawnEnemy(new Vector2(0, 0)));
            EnemyManager.eEnemyType randomEnemyType = (EnemyManager.eEnemyType)Random.Range((int)EnemyManager.eEnemyType.eTemp, (int)EnemyManager.eEnemyType.eEnd);
            EnemyManager.Instance.AddEnemy(randomEnemyType, Vector3.zero);
        }
        Debug.Log(EnemyManager.Instance.GetEnemyListSize());
    }

    private void CheckClear()
    {
        if(EnemyManager.Instance.GetEnemyListSize() <= 0)
        {
            if (!isClear)
            {
                Debug.Log($"{EnemyManager.Instance.GetEnemyListSize()} DungeonClear");
                isClear = true;
                portalObject.SetActive(true);
            }
        }
    }

    private IEnumerator SpawnEnemy(Vector2 pos)
    {
        yield return new WaitForSeconds(1);

        EnemyManager.eEnemyType randomEnemyType = (EnemyManager.eEnemyType)Random.Range((int)EnemyManager.eEnemyType.eTemp, (int)EnemyManager.eEnemyType.eEnd);
        EnemyManager.Instance.AddEnemy(randomEnemyType, Vector3.zero);
    }


}
