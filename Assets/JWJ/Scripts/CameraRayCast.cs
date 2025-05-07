using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRayCast : MonoBehaviour
{

    [SerializeField] private Transform character;
    private Renderer obstacleRenderer;

    void Update()
    {
        float distance = Vector3.Distance(transform.position, character.position);
        Vector3 direction = (character.position - transform.position).normalized;

        RaycastHit hit;

        if (Physics.Raycast(transform.position, direction, out hit, distance))
        {
            Renderer hitRenderer = hit.transform.GetComponentInChildren<Renderer>();

            if (hitRenderer != null && hitRenderer != obstacleRenderer)
            {
                ResetPreviousRenderer(); // ���� ������Ʈ ����

                obstacleRenderer = hitRenderer;

                // ���׸��� ���� ����: ������ �𸣰ڴµ� �� ������Ʈ���� ���� ���� �Ʒ��� �������� �׳� �������� ����
                Material mat = obstacleRenderer.material;
                Color c = mat.color;
                c.a = 0.3f;
                mat.color = c;

                Debug.Log("������Ʈ ���� & ����ȭ: " + hit.transform.name);
            }
        }
        else
        {
            ResetPreviousRenderer();
        }
    }

    void ResetPreviousRenderer()
    {
        if (obstacleRenderer != null)
        {
            Material mat = obstacleRenderer.material;
            Color c = mat.color;
            c.a = 1f;
            mat.color = c;

            obstacleRenderer = null;
        }
    }

}
