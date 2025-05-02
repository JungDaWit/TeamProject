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

    private bool isDead;
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
                    Die();
                }
            }
        }
    }

    void Update()
    {
        if (agent.enabled && target != null)
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
        isDead = true;
        if (OnDeath != null)
        {
            OnDeath();
        }
        Destroy(gameObject);
    }

   
}
