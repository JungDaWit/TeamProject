using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.Events;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("object")]
    [SerializeField] GameObject Player;
    [SerializeField] GameObject Monster;

  [Header("UI")]
  [SerializeField] GameObject StopUi;

    [SerializeField] private bool IsPaues;

    public void Awake() // ���ӸŴ��� �ڵ�����
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject); // �� �� �ڵ� ����
        }
    }
    public void Start()
    {
        
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q)) // ���� �Ͻ������� �Բ� ���Ϳ� �÷��̾� ������Ʈ ��Ȱ��ȭ 
        {
            if (IsPaues == false)
            {
                Debug.Log("���Ӹ���");
                StopUi.SetActive(true);
                Time.timeScale = 0;
                IsPaues = true;
                Monster.SetActive(false);
                Player.SetActive(false);
                return;
            }
            if (IsPaues == true)
            {
                GameContinue();
            }
        }
    }
    public void GameContinue() //���� �Ͻ����� ����
    {
        Debug.Log("���������");
        StopUi.SetActive(false);
        Time.timeScale = 1;
        Monster.SetActive(true);
        Player.SetActive(true);
        IsPaues = false;
    }
   
   
    public void GameOver()
    {
        //TODO : ĳ���� ����� ���ӿ���
    }
}
