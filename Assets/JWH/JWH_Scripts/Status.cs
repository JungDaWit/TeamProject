using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status : MonoBehaviour
{
    //�÷��̾�
    //�÷��̾� ��ũ��Ʈ�� ��������
    [SerializeField] private int PlayerHealth;
    [SerializeField] private int PlayerAttack = 1;

    //private int PlayerCurrentHealth; UI�� ǥ���� ���� �Ƿ�
    private void OnEnable()// �ʱ�ȭ�� �÷��̾� ü��

    {
        PlayerHealth = 10;
    }

    private void PlayerTakeDamage()// �÷��̾�ü��-���Ͱ��ݷ�
    {
        PlayerHealth -= MonsterAttack;

        if (PlayerHealth == 0)
        {
            //����� ���ӸŴ������� �̺�Ʈó��

        }
    }

    //�ѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤ�

    //����
    //���� ��ũ��Ʈ�� ��������
    [SerializeField] private int MonsterHealth = 3;
    [SerializeField] private int MonsterAttack = 1;


    private void MonsterTakeDamage() //���� ü��-�÷��̾� ü��
    {
        MonsterHealth -= PlayerAttack;
        if (MonsterHealth <= 0)// ��� ������
        {
            //Destroy(gameObject);
        }
    }

}