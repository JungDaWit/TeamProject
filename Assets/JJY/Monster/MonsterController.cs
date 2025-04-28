using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    [SerializeField] private GameObject target;
    [SerializeField] float testMoveSpeed = 1; //������̹Ƿ� ���߿� ���� �ʿ�

    private void Start()
    {
        if (target == null)
        {
            target = GameObject.FindWithTag("Player");
        }
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, testMoveSpeed * Time.deltaTime);
        transform.LookAt(target.transform);
    }
}
