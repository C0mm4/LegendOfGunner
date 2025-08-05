using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DungeonManager : MonoBehaviour
{
    [SerializeField]
    SpriteRenderer fadeSprite;
    public int wave;
    bool isClear;
    private int ememySpawnCount = 15;
    [SerializeField]
    private GameObject portalObject;
    [SerializeField]
    private GameObject[] dungeonFieldObjects;
    
    [SerializeField]
    private GameObject[] dungeonBossMapPrefs;
    [SerializeField]
    private TextMeshProUGUI waveUIText;

    [SerializeField]
    private GameObject spawnCirclePref;

    private bool isSpawnning = false;
    private float lastSpawnT = 0;

    private GameObject prevDungeonFieldObj;
    public GameObject CurrentDungeonMap { get { return prevDungeonFieldObj; } }
    [SerializeField]
    private List<Rect> spawnRects;


    [SerializeField]
    public int stage;
    bool isClearGame = false;
    [SerializeField]
    public int currentWaveInStage;

    [SerializeField]
    public int targetToBossWave;
    private bool _isBossStage = false;
    public bool isBossStage { get { return _isBossStage; } set { _isBossStage = value; } }

    void Start()
    {
        targetToBossWave = Random.Range(3, 6);
        stage = 1;
        StartDungeon();
        isBossStage = false;
        isClearGame = false;
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
                }
                // 현재 웨이브가 보스까지의 웨이브일 시 보스방 생성 및 초기화
                if (currentWaveInStage == targetToBossWave - 1)
                {
                    isBossStage = true; 
                    int selectRandomDungeon = Random.Range(0, dungeonBossMapPrefs.Length);
                    Debug.Log(dungeonBossMapPrefs.Length);
                    Debug.Log(selectRandomDungeon);
                    prevDungeonFieldObj = Instantiate(dungeonBossMapPrefs[selectRandomDungeon], Vector3.zero, Quaternion.identity, transform);
                    Tilemap tilemap = prevDungeonFieldObj.GetComponentInChildren<Tilemap>();
                    Camera.main.GetComponent<FollowCamera>().SetTilemap(tilemap);
                }
                else
                {
                    int selectRandomDungeon = Random.Range(0, dungeonFieldObjects.Length);
                    Debug.Log(dungeonFieldObjects.Length);
                    Debug.Log(selectRandomDungeon);
                    prevDungeonFieldObj = Instantiate(dungeonFieldObjects[selectRandomDungeon], Vector3.zero, Quaternion.identity, transform);
                    Tilemap tilemap = prevDungeonFieldObj.GetComponentInChildren<Tilemap>();
                    Camera.main.GetComponent<FollowCamera>().SetTilemap(tilemap);
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
    }

    private void CreateWave()
    {
        currentWaveInStage++;
        if (isBossStage == true)
        {
            StartCoroutine(SpawnBoss(GetRandomPos()));
        }
        else
        {
            for (int i = 0; i < ememySpawnCount; i++)
            {
                StartCoroutine(SpawnEnemy(GetRandomPos()));
            }
        }
    }

    private void CheckClear()
    {
        if (EnemyManager.Instance.GetEnemyListSize() <= 0)
        {
            if (!isClear)
            {
                Debug.Log($"{EnemyManager.Instance.GetEnemyListSize()} DungeonClear");
                if (stage == 3 && currentWaveInStage == targetToBossWave)
                {
                    isClearGame = true;
                }
                else
                {
                    isClear = true;
                    portalObject.SetActive(true);
                    if (isBossStage == true)
                    {
                        currentWaveInStage = 0;
                        stage++;
                    }
                }
                if (isClearGame)
                {
                    UIManager.Instance.ActiveGameEndUI(false);
                }
            }
        }
    }

    public IEnumerator SpawnEnemy(Vector2 pos)
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
        return prevDungeonFieldObj.GetComponent<Map>().GetRandomPos();
    }

}
