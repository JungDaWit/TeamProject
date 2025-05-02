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

        
    }


    public void RegisterMonster(MonsterController monster)
    {
        if (monster != null)
        {
            Debug.Log("���� ��� �õ�");
            monster.OnDeath += CheckMonsterDeath;
        }
        else
        {
            Debug.LogWarning("����Ϸ��� ���Ͱ� null�Դϴ�.");
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
            Debug.Log("���� Ŭ����!");
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