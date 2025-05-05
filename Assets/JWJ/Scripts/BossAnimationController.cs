using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAnimationController : MonoBehaviour
{
    private Animator animator;
    private BossController BossController;
    private float attackRange = 2.5f;
    private bool isAttacking = false;
    private Transform player;
    

    private void Awake()
    {
        animator = GetComponent<Animator>();
        BossController = GetComponentInParent<BossController>();
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        player = playerObj.transform;
    }

    private void Update()
    {
        

        float distance = Vector3.Distance(transform.position, player.position); //�÷��̾���� �Ÿ�
       // Debug.Log("�÷��̾���� �Ÿ�: " + distance);

        if (distance < attackRange && isAttacking == false && BossController.isDashing == false)
        {
            RandomAttack();
            isAttacking = true;
            Invoke(nameof(AttackDelay), 2f); // ���� ������
        }


    }

    public void BossDied()
    {
        Debug.Log("���� ����");
        
        animator.SetTrigger("Die");
        AudioManager.instance.PlaySfx(AudioManager.Sfx.BossDead); //����� ���
    }


//�����ִ�
public void BossSpawn()
    {
        
        animator.SetTrigger("Spawn");
       AudioManager.instance.PlaySfx(AudioManager.Sfx.BossSpawn);
    }


    //���� ����Ʈ
    public void Dash()
    {
        
        animator.SetTrigger("Dash");
        AudioManager.instance.PlaySfx(AudioManager.Sfx.BossDash); // ����� ���
    }

    public void RightAttack()
    {
        animator.SetTrigger("RightAttack");
        AudioManager.instance.PlaySfx(AudioManager.Sfx.BossAttack); // ����� ���
    }

    public void LeftAttack()
    {
        animator.SetTrigger("LeftAttack");
        AudioManager.instance.PlaySfx(AudioManager.Sfx.BossAttack); // ����� ���
    }

    public void BiteAttack()
    {
        animator.SetTrigger("BiteAttack");
       AudioManager.instance.PlaySfx(AudioManager.Sfx.BossAttack); // ����� ���
    }


    
    private void AttackDelay()  // ���� ������
    {
        isAttacking = false;
    }

    private void RandomAttack()
    {
        if (BossController.isDead == true)
        {
            return;
        }

        else
        {
            int random = UnityEngine.Random.Range(0, 3); // 0, 1, 2 �� �ϳ�

            switch (random)
            {
                case 0:
                    
                    RightAttack();
                    break;
                case 1:
                    
                    LeftAttack();
                    break;
                case 2:
                    
                    BiteAttack();
                    break;
            }
        }
        
    }
}



