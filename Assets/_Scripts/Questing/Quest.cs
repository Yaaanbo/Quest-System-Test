using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[CreateAssetMenu(fileName = "New Quest", menuName = "Create Quest")]
public class Quest :ScriptableObject
{
    [Header("Quest Info")]
    public QuestType questType;
    public string questTitle;
    public string questDesc;

    [Header("Quest Condition")]
    public int requiredAmount;
    public int currentAmount;
    public bool isQuestActive;

    [Header("Conversation Quest")]
    public string npcName;

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

    public void NpcTalking(TMP_Text _convoTxt, TMP_Text _nameTxt, string _npcName, string _npcQuestConv, string _npcNormalConv)
    {
        _nameTxt.text = _npcName;
        if (questType == QuestType.Talking && isQuestActive)
        {
            if (npcName == _npcName)
            {
                _convoTxt.text = _npcQuestConv;
                currentAmount++;
            }
        }
        else
        {
            _convoTxt.text = _npcNormalConv;
        }
    }
}

public enum QuestType
{
    Killing,
    Gathering,
    Talking
}
