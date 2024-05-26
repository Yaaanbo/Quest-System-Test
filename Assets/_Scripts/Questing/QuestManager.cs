using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestManager : MonoBehaviour
{
    public static QuestManager Instance;

    [Header("Quest Hander")]
    [SerializeField] private Quest[] quest;
    public Quest currentQuest { get; private set; }
    private int currentQuestIndex;

    [Header("UIs")]
    [SerializeField] private TMP_Text questTitleTxt;
    [SerializeField] private TMP_Text questDescriptionTxt;

    private void Awake()
    {
        if(Instance == null)
            Instance = this;
        else
            Destroy(Instance);
    }

    private void Start()
    {
        SetUpQuest();
        SetQuestUI();
    }

    private void SetUpQuest()
    {
        currentQuest = quest[currentQuestIndex];
        currentQuest.isQuestActive = true;

        SetQuestUI();
    }

    public void TrackProgress()
    {
        SetQuestUI();
        if (currentQuest.currentAmount >= currentQuest.requiredAmount)
        {
            Debug.Log("Quest Complete");
            currentQuest.isQuestActive = false;
            currentQuest.currentAmount = 0;

            NextQuest();
        }
    }

    private void NextQuest()
    {
        if (currentQuestIndex >= quest.Length - 1)
        {
            Debug.Log("No More Quest!");
            questTitleTxt.gameObject.SetActive(false);
            questDescriptionTxt.gameObject.SetActive(false);
        }
        else
        {
            currentQuestIndex++;
            SetUpQuest();
        }
    }

    private void SetQuestUI()
    {
        questTitleTxt.text = currentQuest.questTitle;
        questDescriptionTxt.text = currentQuest.questDesc + $"({currentQuest.currentAmount} / {currentQuest.requiredAmount})";
    }
}
