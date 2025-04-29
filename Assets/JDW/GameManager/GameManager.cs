using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    [SerializeField] GameObject timer;

   

  [Header("UI")]
  [SerializeField] GameObject StopUi;

   [SerializeField] private bool IsPaues;

    public void Awake() // ���ӸŴ��� �ڵ�����
    {
        if(Instance == null)
        {
            Instance = this;
            Resources.Load<GameObject>("GameManager");
            //DontDestroyOnLoad(gameObject);
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
        if (Input.GetKeyDown(KeyCode.Q)) // ���Ϳ� �÷��̾� ������Ʈ ��Ȱ��ȭ �� �Բ� ui���
        {
            if (IsPaues == false)
            {
                Debug.Log("���Ӹ���");
                stopUi();
                timer.SetActive(false);
              // Time.timeScale = 0;
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
        // Time.timeScale = 1;
        timer.SetActive(true);
        Monster.SetActive(true);
        Player.SetActive(true);
        IsPaues = false;
    }
    private void stopUi()
    {
        StopUi.SetActive(true);

    }

   
   
    public void GameOver()
    {
        //TODO : ĳ���� ����� ���ӿ���
    }
}
