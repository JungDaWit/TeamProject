using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAniController : MonoBehaviour
{
    public Animator anima;
    private MonsterController monsterController;
    private float lastHP;
    private float attackRange = 1.3f;
    private Transform player;
    private bool isAttacking;

    // Start is called before the first frame update
    void Start()
    {
        anima = GetComponent<Animator>();
        monsterController = GetComponentInParent<MonsterController>();
        lastHP = monsterController.monsterHP;
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        player = playerObj.transform;
    }

    private void Update()
    {
        if(monsterController.monsterHP < lastHP)
        {
            anima.SetTrigger("MonsterGetDamaged");
            lastHP = monsterController.monsterHP;
        }

    float distance = Vector3.Distance(transform.position, player.position);  //�����̿� ���� ����

        if (distance < attackRange && isAttacking == false)
        {
            anima.SetTrigger("MonsterAttack");
            isAttacking = true;
            Invoke(nameof(AttackDelay), 0.5f); // ���� ������

        }

        }

    private void AttackDelay()  // ���� ������
    {
        isAttacking = false;
    }

        //  if(monsterController.monsterHP <= 0)  //���� �״¸��
        //  {
        //      anima.SetTrigger("MonsterDied");
        //      //lastHP = 0;
        //  }
    }

