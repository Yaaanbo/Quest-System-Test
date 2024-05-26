using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NPC : MonoBehaviour
{
    [Header("Npc Info")]
    [SerializeField] private string npcName;
    [SerializeField] private string npcNormalConv;
    [SerializeField] private string npcQuestConv;

    [Header("UIs")]
    [SerializeField] private GameObject npcConvUI;
    [SerializeField] private TMP_Text npcConvTxt;
    [SerializeField] private TMP_Text npcNameTxt;
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            npcConvUI.SetActive(true);
            QuestManager.Instance.currentQuest.NpcTalking(npcConvTxt, npcNameTxt, npcName, npcQuestConv, npcNormalConv);
            QuestManager.Instance.TrackProgress();
        }

        if ((Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.F)) && npcConvUI.activeInHierarchy)
        {
            npcConvUI.SetActive(false);
        }
    }
}
