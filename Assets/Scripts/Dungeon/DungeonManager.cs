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
    private TextMeshProUGUI waveUIText;
    bool isStartGame = false;

    void Start()
    {
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
        fadeSprite.DOFade(0, 3.5f).OnComplete(() =>
        {
            isClear = false;
            maxWave = Random.Range(3, 6);
            isStartGame = true;

        });
        wave++;
        waveUIText.SetText(wave.ToString());

        EnemyManager.Instance.AddBoss(1, Vector3.zero);

    }

    void Update()
    {
        if (isClear == false && isStartGame == true)
            WaveLogic();
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
                    // EnemyManager.eEnemyType randomEnemyType = (EnemyManager.eEnemyType)Random.Range((int)EnemyManager.eEnemyType.eTemp, (int)EnemyManager.eEnemyType.eEnd);
                    // EnemyManager.Instance.AddEnemy(randomEnemyType, Vector3.zero);
                }
                wave++;
                waveUIText.SetText(wave.ToString());
            }
        }
    }
}
