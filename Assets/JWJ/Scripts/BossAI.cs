using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossAI : MonoBehaviour
{
    /// <summary>
    /// �Ⱦ��� ��ũ��Ʈ
    /// </summary>
    public Transform target;

    private NavMeshAgent agent;
    private BossAnimationController animController;
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

    void Update()
    {
        if (agent.enabled && target != null)
        {
            agent.SetDestination(target.position);
        }
    }
}
