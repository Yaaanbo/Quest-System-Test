using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Quest
{
    [Header("Quest Info")]
    public QuestType questType;
    public string questTitle;
    public string questDesc;

    [Header("Quest Condition")]
    public int requiredAmount;
    public int currentAmount;

    public bool isQuestActive;

    public void EnemySlain()
    {
        if (questType == QuestType.Killing && isQuestActive)
            currentAmount++;
    }

    public void ItemGathered()
    {
        if (questType == QuestType.Gathering && isQuestActive)
            currentAmount++;
    }
}

public enum QuestType
{
    Killing,
    Gathering,
    Talking
}
