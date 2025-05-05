using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public class BossController : MonoBehaviour
{
    [SerializeField] public float bossAttack;
    [SerializeField] public float bossHP;

    [SerializeField] private float dashTryTime;  // �뽬 �õ� ��
    [SerializeField] private float dashTime;  // �뽬 ���ӽð�
    [SerializeField] private float dashSpeed;  // �뽬 ���ǵ�
    [SerializeField] private float dashChance; // �뽬 �õ��� ���� Ȯ��

    public Transform target;

    private Rigidbody rb;
    private NavMeshAgent agent;

    public bool isDead;
    public event Action OnDeath;
    private BossAnimationController animController;
    public bool isDashing = false;

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

        InvokeRepeating(nameof(TryDash), dashTryTime, dashTryTime); //�ֱ������� �뽬 �õ�
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
                Debug.Log("�뽬 ����");
                animController.Dash();

                Invoke(nameof(DashCoroutine), 1f);  // �ִϸ��̼� �����ϰ� �뽬
                

            }
        }


    }

    private void DashCoroutine()
    {
        StartCoroutine(Dash());
    }



    private IEnumerator Dash()
    {
        isDashing = true;
        agent.enabled = false;
        

        float timer = 0f;

        while (timer < dashTime)
        {
            rb.velocity = transform.forward * dashSpeed;
            timer += Time.deltaTime;
            yield return null;
        }

        rb.velocity = Vector3.zero;
        agent.enabled = true;
        isDashing = false;

        Debug.Log("�뽬 ����");
    }


  //  private void DashFalse()
  //  {
  //      isDashing = false;
  //      rb.velocity = Vector3.zero;
  //      //agent.Warp(transform.position); // �׺������ �ٽ� ������ ���� ��ġ ����
  //      agent.enabled = true;
  //
  //      Debug.Log("�뽬����");
  //
  //
  //
  //  }

    void StartChasing()
    {
        agent.enabled = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet") && !isDead)
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
