using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Achievement 
{
    public string Name {  get; private set; }
    public string Desc { get; private set; }

    public bool IsUnlock { get; private set; }


    private IAchievementCondition condition;

    public Achievement(string title, string description, IAchievementCondition condition)
    {
        Name = title;
        Desc = description;
        this.condition = condition;
        IsUnlock = false;
    }

    public void CheckUnlock()
    {
        if (IsUnlock) return;
        if (condition == null) return;
        if (condition.IsSatisfied())
        {
            IsUnlock = true;
            Debug.Log($"{Name} Unlock");
        }
    }

}

