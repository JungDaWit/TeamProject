using System.Collections;
using UnityEngine;

public class SpiderAniController : MonoBehaviour
{
    public Animator anima;
    private MonsterController monsterController;
    private float lastHP;
    private float attackRange = 1.3f;
    private Transform player;
    private bool isAttacking;
    private bool isDead = false;

    [SerializeField] float deathdelay = 1.5f;

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
        if(monsterController.monsterHP <= 0)  //���� �״¸��
        {
            isDead = true;
            anima.SetTrigger("MonsterDied");
            StartCoroutine(DeathDelay());
        }

        if (monsterController.monsterHP < lastHP)
        {
            anima.SetTrigger("MonsterGetDamaged");
            lastHP = monsterController.monsterHP;
        }

        float distance = Vector3.Distance(transform.position, player.position);  //�����̿� ���� ����

        if (distance < attackRange && isAttacking == false)
        {
            anima.SetTrigger("MonsterAttack");
            isAttacking = true;
            Invoke(nameof(AttackDelay), 1f); // ���� ������

        }

    }

    private void AttackDelay()  // ���� ������
    {
        isAttacking = false;
    }

    private IEnumerator DeathDelay()
    {
        yield return new WaitForSeconds(deathdelay);
        Destroy(monsterController.gameObject);
    }

}

