using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePlayer : MonoBehaviour
{
    public PlayerController playerController;
    //public float playerHpSave;

    
    public void SaveHp()
    {
        if (playerController != null)
        {
            //playerHpSave = 
                PlayerPrefs.SetFloat("PlayerHealth", playerController.playerHP);
            PlayerPrefs.Save();
            Debug.Log($"{playerController.playerHP}�÷��̾� ü�� ����");
        }
        else
        {
            Debug.LogError("�������");
        }
    }

    
   
}

//�÷��̾  �־ ���
//�ν����Ϳ� �÷��̾� �ֱ� (�÷��̾ �÷��̾���Ʈ�ѷ� ��ũ��Ʈ�� ����־����)
