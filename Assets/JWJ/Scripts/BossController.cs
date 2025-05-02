using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public class BossController : MonoBehaviour
{
    [SerializeField] public float bossAttack;
    [SerializeField] public float bossHP;

    public Transform target;

    private Rigidbody rb;
    private NavMeshAgent agent;

    public bool isDead;
    public event Action OnDeath;
    private BossAnimationController animController;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        agent = GetComponent<NavMeshAgent>();
    }

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animController = GetComponent<BossAnimationController>();

        agent.enabled = false;
        animController.BossSpawn();  // ������ ����
        Invoke("StartChasing", 3f); //������ 3�ʵں��� �÷��̾� ����
    }

    void StartChasing()
    {
        agent.enabled = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Bullet bullet = collision.gameObject.GetComponent<Bullet>();
            if (bullet != null)
            {
                TakeDamage(bullet.bulletDamage);
                collision.gameObject.SetActive(false);

                if (bossHP <= 0)
                {
                    isDead = true;
                    agent.enabled = false;
                    animController.BossDied(); //���� �״¸��
                    Die();
                    
                }
            }
        }
    }

    void Update()
    {
        if (!isDead && agent.enabled && target != null)
        {
            agent.SetDestination(target.position);
        }
    }

    private void TakeDamage(float damage)
    {
        bossHP -= damage;
        AudioManager.instance.PlaySfx(AudioManager.Sfx.MonsterGetDamaged); // JWJ �߰� ����� ���
        Debug.Log("���� ü�� :" + bossHP); // �߰�
    }
    private void Die()
    {
        

        
        Invoke(nameof(DeathDelay), 3f); //������� �ð� ������
        

        if (OnDeath != null)
        {
            OnDeath();
 
        }
        
    }

    private void DeathDelay()
    {
        Destroy(gameObject);
    }

   
}
