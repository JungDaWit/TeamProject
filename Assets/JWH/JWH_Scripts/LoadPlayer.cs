using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadPlayer : MonoBehaviour
{

    
    public float playerHpNextScene; // ���� ������ ����� �÷��̾� ü��

   
    void Start()
    {
        LoadPlayerHp();
        
        Debug.Log($"�÷��̾� ü�� �ҷ�����");
    }

    void LoadPlayerHp()
    {
        
        playerHpNextScene = PlayerPrefs.GetFloat("PlayerHealth");
    }


    public float PlayerHealth
    {
        get { return playerHpNextScene; }
    }
}
// �÷��̾�� �ִ� ��ũ��Ʈ