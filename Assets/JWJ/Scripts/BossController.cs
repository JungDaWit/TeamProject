using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public class BossController : MonoBehaviour
{
    [SerializeField] public float bossAttack;
    [SerializeField] public float bossHP;

    [SerializeField] private float dashTryTime;
    [SerializeField] private float dashTime;
    [SerializeField] private float dashSpeed;
    [SerializeField] private float dashChance;

    public Transform target;

    private Rigidbody rb;
    private NavMeshAgent agent;

    public bool isDead;
    public event Action OnDeath;
    private BossAnimationController animController;
    private bool isDashing = false;

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

        InvokeRepeating(nameof(TryDash), dashTryTime, dashTime); //�ֱ������� �뽬 �õ�
    }

    private void TryDash()
    {
        if (isDead || isDashing || agent.enabled == false) //�׾��ų� �뽬���̰ų� AIȰ��ȭ ���϶� �������
            return;

        else
        {
            int random = UnityEngine.Random.Range(0, 100);
            if (random < dashChance)
            {
                isDashing = true;
                agent.enabled = false;


                animController.Dash();

                Vector3 dashdirection = transform.forward.normalized;
                float dashstartTime = Time.time;
                rb.velocity = transform.forward.normalized * dashSpeed;

                Invoke("DashFalse", dashTime);

            }
        }


    }

    private void DashFalse()
    {
        isDashing = false;
        rb.velocity = Vector3.zero;
        agent.Warp(transform.position); // �׺������ �ٽ� ������ ���� ��ġ ����
        agent.enabled = true;

        Debug.Log("�뽬����");



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
        if (!isDead && !isDashing && agent.enabled && target != null)
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
