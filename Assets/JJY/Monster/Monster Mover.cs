using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class MonsterMover : MonoBehaviour
{
    [SerializeField] public float MoveSpeed = 1f;
    Transform target;
    NavMeshAgent pathfinder;

    private void Start()
    {
        pathfinder = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine(UpdatePath());
    }
    IEnumerator UpdatePath()
    {
        float delay = 0.1f; // update�� �̵��� �����ϸ� �����Ӹ��� ����ϱ⿡ refreshRate���� ����ϰ� �̵��ϵ��� ����

        while (target != null)
        {
            Vector3 targetPosition = new Vector3(target.position.x, 0, target.position.z);
            pathfinder.SetDestination(targetPosition);
            yield return new WaitForSeconds(delay);
        }
    }
}
