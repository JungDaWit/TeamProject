using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Potal : MonoBehaviour
{
    public string targetSceneName;

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (targetSceneName == null)
            {
                Debug.LogError(gameObject.name + "null");
                return; 
            }

            SceneManager.LoadScene(targetSceneName);
        }
    }
    
}
// ����� ������Ʈ����
//Collider ������Ʈ is Triger üũ�ϱ�
// �÷��̾� �±� �����ϱ�!

