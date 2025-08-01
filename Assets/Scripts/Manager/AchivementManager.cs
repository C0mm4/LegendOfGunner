using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchivementManager : MonoSingleton<AchivementManager>
{
    private List<Achievement> achievements = new List<Achievement>();

    // 조건에 접근할 수 있게 보관 (예: 킬 카운트)
    private KillByIDCondition killCountCondition;
    private StageClearCondition stageCondition;

    private List<KillByIDCondition> killConditions = new();
    private List<StageClearCondition> stageConditions = new();

    void Start()
    {
        // Add Initialize Achievements
        killCountCondition = new KillByIDCondition(new Dictionary<int, int> { { 0, 5 }}); // 보스 ID
        stageCondition = new StageClearCondition(3);
        killConditions.Add(killCountCondition);
        stageConditions.Add(stageCondition);

        achievements.Add(new Achievement("Boss Slayer", "Defeat Boss", killCountCondition));
        achievements.Add(new Achievement("Clear Stage 3", "Complete Stage 3", stageCondition));
    }

    public void OnEnemyKilled(int enemyID)
    {
        foreach(var kill in killConditions)
        {
            kill.AddKill(enemyID);
        }
        CheckAchievements();
    }

    public void OnStageCleared(int stage)
    {
        stageCondition.SetClearedStage(stage);
        CheckAchievements();
    }

    public void CheckAchievements()
    {
        foreach (var a in achievements)
        {
            a.CheckUnlock();
        }
    }
}
