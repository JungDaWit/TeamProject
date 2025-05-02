using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LordPlayer : MonoBehaviour
{


    //public float playerHpNextScene; // ���� ������ ����� �÷��̾� ü��
    public PlayerController playerController;

    void Start()
    {
        float loadedHp = PlayerPrefs.GetFloat("PlayerHealth", 100f); // �⺻�� ����-ü�� �ִ밪 ���� ���Ѿ� �ڿ�������!!!!
        Debug.Log($"�÷��̾� ü�� �ҷ����� {loadedHp}");

        if (playerController != null)
        {
            playerController.playerHP = loadedHp;
        }
        else
        {
            Debug.LogError("LoadPlayer ���� �� ��");
        }
    }



}
// ���� ���������� �÷��̾�� �ִ� ��ũ��Ʈ
// �ν����Ϳ� player �ֱ� (����� �÷��̾� ������Ʈ�� ������ �۵�)
