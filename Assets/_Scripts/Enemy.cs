using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float maxHp;
    private float currentHp;

    // Start is called before the first frame update
    void Start()
    {
        currentHp = maxHp;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            TakeDamage();
        }
    }

    private void TakeDamage()
    {
        currentHp--;
        if(currentHp <= 0)
        {
            currentHp = maxHp;
            QuestManager.Instance.currentQuest.EnemySlain();
            QuestManager.Instance.TrackProgress();
        }
    }
}
