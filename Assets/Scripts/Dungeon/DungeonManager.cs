using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DungeonManager : MonoBehaviour
{
    [SerializeField]
    SpriteRenderer fadeSprite;
    public int wave;
    bool isClear;
    private int ememySpawnCount = 5;
    [SerializeField]
    private GameObject portalObject;
    [SerializeField]
    private GameObject[] dungeonFieldObjects;
    [SerializeField]
    private GameObject[] dungeonFields;
    [SerializeField]
    private TextMeshProUGUI waveUIText;

    [SerializeField]
    private GameObject spawnCirclePref;

    private bool isSpawnning = false;
    private float lastSpawnT = 0;

    private GameObject prevDungeonFieldObj;
    private GameObject prevDungoneWallObj;

    [SerializeField]
    private List<Rect> spawnRects;


    [SerializeField]
    public int stage;

    [SerializeField]
    public int currentWaveInStage;

    [SerializeField]
    public int targetToBossWave;
    private bool isBossStage = false;

    void Start()
    {
        targetToBossWave = Random.Range(3, 6);
        stage = 1;
        StartDungeon();
        isBossStage = false;
    }

    void Update()
    {
        if (isSpawnning)
        {
            lastSpawnT += Time.deltaTime;
            // Clear check After 5 sec
            if (lastSpawnT >= 5f)
                isSpawnning = false;
        }
        else
        {
            if (isClear == false)
            {
                CheckClear();
            }
        }
    }

    public void StartDungeon()
    {
        isSpawnning = true;
        isClear = false;
        portalObject.SetActive(false);
        lastSpawnT = 0;
        wave++;
        GameManager.gameState = GameState.Load;
        fadeSprite.gameObject.SetActive(true);
        fadeSprite.DOFade(1, 1f).OnComplete(() =>
        {
            // 여기서 UI 갱신
            if (waveUIText != null)
                waveUIText.SetText(wave.ToString());


            if (dungeonFieldObjects != null)
            {
                if (prevDungeonFieldObj != null)
                {
                    Destroy(prevDungeonFieldObj);
                    Destroy(prevDungoneWallObj);
                }
                // 현재 웨이브가 보스까지의 웨이브일 시 보스방 생성 및 초기화
                if (currentWaveInStage == targetToBossWave)
                {
                    currentWaveInStage = 0;
                    stage++;
                    isBossStage = true;
                }
                else
                {
                    int selectRandomDungeon = Random.Range(0, dungeonFieldObjects.Length);
                    prevDungeonFieldObj = Instantiate(dungeonFields[selectRandomDungeon], Vector3.zero, Quaternion.identity, transform);
                    prevDungoneWallObj = Instantiate(dungeonFieldObjects[selectRandomDungeon], Vector3.zero, Quaternion.identity, transform);
                    isBossStage = false;
                }
            }
            else
            {
                Debug.Log("�����ʵ尡 �����ϴ�");
            }

            fadeSprite.DOFade(0, 1f).OnComplete(() =>
            {
                isClear = false;
                fadeSprite.gameObject.SetActive(false);
                GameManager.gameState = GameState.InPlay;
                CreateWave();
            });

        });
        //EnemyManager.Instance.AddBoss(1, Vector3.zero); ���� �׽�Ʈ �ڵ�
    }
    /*
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
                    waveUIText.SetText(wave.ToString());
                }
            }
        }
    */
    private void CreateWave()
    {
        currentWaveInStage++;
        if (isBossStage == false)
        {
            StartCoroutine(SpawnBoss(GetRandomPos()));
        }
        else
        {
            for (int i = 0; i < 5; i++)
            {
                StartCoroutine(SpawnEnemy(GetRandomPos()));
            }
        }
        //Debug.Log(EnemyManager.Instance.GetEnemyListSize());
        //
    }

    private void CheckClear()
    {
        if (EnemyManager.Instance.GetEnemyListSize() <= 0)
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
    private IEnumerator SpawnBoss(Vector2 pos)
    {
        yield return new WaitForSeconds(0.2f);
        Debug.Log("test");
        GameObject go = Instantiate(spawnCirclePref, pos, Quaternion.identity);
        go.GetComponent<SpawnCircle>().SetBossData(1);
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
        foreach (Rect rect in spawnRects)
        {
            float centerX, centerY;
            centerX = (rect.xMin + rect.xMax) / 2;
            centerY = (rect.yMin + rect.yMax) / 2;

            Gizmos.DrawCube(new Vector3(centerX, centerY), new Vector3(rect.width, rect.height));
        }
    }
}
