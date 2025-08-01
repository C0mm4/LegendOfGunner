using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageClearCondition : IAchievementCondition
{
    private int requiredStage;
    private int clearedStage;

    public StageClearCondition(int stage)
    {
        requiredStage = stage;
        clearedStage = 0;
    }

    public void SetClearedStage(int stage)
    {
        clearedStage = Mathf.Max(clearedStage, stage);
    }

    public bool IsSatisfied()
    {
        return clearedStage >= requiredStage;
    }

    public void UpdateCondition() { }
}
