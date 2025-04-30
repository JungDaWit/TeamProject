using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterCount : MonoBehaviour
{
    public Text KillCount; //óġ�� ���� text

    
    [SerializeField] int TargetKillCount = 10; // Ŭ���� ��ǥ
    private int CurrentKillCount = 0;
    private int displayedTargetKillCount; // ǥ�õǴ� ��ǥ óġ ��

    void Start()
    {
        displayedTargetKillCount = TargetKillCount;
        UpdateKillCountUI();
       
        MonsterController[] monsters = FindObjectsOfType<MonsterController>();
        foreach (MonsterController monster in monsters)
        {
            monster.OnDeath += CheckMonsterDeath;
        }
    }

    void CheckMonsterDeath()
    {
        CurrentKillCount++;
        displayedTargetKillCount--;
        UpdateKillCountUI();

        
        if (CurrentKillCount >= TargetKillCount)// ��ǥ ų�� Ȯ���ϴ� �κ�
        {
            // ����Ŭ���� ��� �κ�
        }
    }

    void UpdateKillCountUI()
    {
        if (KillCount != null)
        {
            KillCount.text = string.Format("���� ��ǥ: {0}", displayedTargetKillCount);
        }
    }

   

    
}