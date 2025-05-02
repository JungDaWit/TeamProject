using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Potal : MonoBehaviour
{
    public static Potal PotalInstance;
    public string targetSceneName;
    public SavePlayer savePlayer;

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))// �÷��̾� �±� Ž��
        {
            if (targetSceneName == null)
            {
                Debug.LogError($"{gameObject.name} Ÿ�پ� ����");
                return; 
            }

            

            if (savePlayer != null) // ü������
            {
                savePlayer.SaveHp();
            }
            else
            {
                Debug.LogError($"{gameObject.name} ü�¾���");
            }

            SceneManager.LoadScene(targetSceneName);
            Debug.Log($"Loading scene: {targetSceneName}");
        }
    }
    
}
// ����� ������Ʈ����
//Collider ������Ʈ is Triger üũ�ϱ�
// �÷��̾� �±� �����ϱ�!
// SavePlayer ��ũ��Ʈ�� �� �÷��̾ �ν����Ϳ��� �����ϱ� @@@@@@@@@@@@@

