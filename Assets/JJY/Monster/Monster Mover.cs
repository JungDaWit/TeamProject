using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Animations;

[RequireComponent(typeof(NavMeshAgent))]
public class MonsterMover : MonoBehaviour
{
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
        float delay = 0.01f; // update�� �̵��� �����ϸ� �����Ӹ��� ����ϱ⿡ delay���� ����ϰ� �̵��ϵ��� ����

        while (target != null)
        {
            Vector3 targetPosition = new Vector3(target.position.x, 0, target.position.z);
            pathfinder.SetDestination(targetPosition);
            yield return new WaitForSeconds(delay);
        }
    }
}
