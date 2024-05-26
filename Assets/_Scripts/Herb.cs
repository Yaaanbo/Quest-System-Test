using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Herb : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            QuestManager.Instance.currentQuest.ItemGathered();
            QuestManager.Instance.TrackProgress();
        }
    }
}
