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

    [SerializeField]
    private GameObject spawnCirclePref;

    private bool isSpawnning = false;
    private float lastSpawnT = 0;

    private GameObject prevDungeonFieldObj;
    private GameObject prevDungoneWallObj;

    [SerializeField]
    private List<Rect> spawnRects;

    void Start()
    {
        StartDungeon();
    }

    void Update()
    {
        if (isSpawnning)
        {
            lastSpawnT += Time.deltaTime;
            // 3초 뒤 소환 판정 종료
            if (lastSpawnT >= 3f)
                isSpawnning = false;
        }
        else
        {
            // 소환 판정 종료시 던전 클리어 체크
            if (isClear == false)
            {
                CheckClear();
            }
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
        isSpawnning = true;
        lastSpawnT = 0;
        for (int i = 0; i < ememySpawnCount; i++)
        {
            
            StartCoroutine(SpawnEnemy(GetRandomPos()));

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
        yield return new WaitForSeconds(0.2f);

        EnemyManager.eEnemyType randomEnemyType = (EnemyManager.eEnemyType)Random.Range((int)EnemyManager.eEnemyType.eTemp, (int)EnemyManager.eEnemyType.eEnd);
        GameObject go = Instantiate(spawnCirclePref, pos, Quaternion.identity);
        go.GetComponent<SpawnCircle>().SetEnemyData(randomEnemyType);
    }

    private Vector2 GetRandomPos()
    {
        int randIndex = Random.Range(0, spawnRects.Count);

        float randX = Random.Range(spawnRects[randIndex].xMin, spawnRects[randIndex].xMax);
        float randY = Random.Range(spawnRects[randIndex].yMin, spawnRects[randIndex].yMax);
        return new Vector2(randX, randY);
    }

    private void OnDrawGizmosSelected()
    {
        foreach(Rect rect in spawnRects)
        {
            float centerX, centerY;
            centerX = (rect.xMin + rect.xMax) / 2;
            centerY = (rect.yMin + rect.yMax) / 2;

            Gizmos.DrawCube(new Vector3(centerX, centerY), new Vector3(rect.width, rect.height));
        }
    }
}
