using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;



public class Timer : MonoBehaviour
{
    public Text[] timeText;
    public Text GameOverText;
    public float time = 10; // ���� �ð�
   // [SerializeField] float time = 10; // ���� �ð�
    int min, sec; //���� �ʹ� ���ٸ� �ʸ� ���
    
    void Start()
    {
        UpdateTimeUI(); // �ʱ� UI ������Ʈ
        if (GameOverText != null)
        {
            GameOverText.gameObject.SetActive(false); // ���� ���� �ؽ�Ʈ=���û���
        }

    }

    void Update()
    {
        time -= Time.deltaTime;

        if (time <= 0)
        {
            time = 0;
            GameManager.Instance.OnTimer.Invoke();
            //  UpdateTimeUI();
            //  // ���� ���� ó�� �ؽ�Ʈ�� (Ÿ�̸Ӱ� ���ߴ� ���)
            //  if (GameOverText != null)
            //  {
            //      GameManager.Instance.OnTimer.Invoke();
            //      //GameOverText.gameObject.SetActive(true);// ���ӿ��� �ؽ�Ʈ
            //  }
            //  enabled = false; // Ÿ�̸� ���� 
        }
        else
        {
            UpdateTimeUI();
        }
    }

    void UpdateTimeUI()
    {
        min = Mathf.FloorToInt(time / 60);//�� 
        sec = Mathf.FloorToInt(time % 60);//��

        if (timeText != null && timeText.Length >= 2)
        {
            timeText[0].text = min.ToString("D2"); // ���� �� �ڸ� ���ڷ� ǥ�� -> D1(���ڸ��� ǥ��)
            timeText[1].text = sec.ToString("D2"); // �ʸ� �� �ڸ� ���ڷ� ǥ��
        }
       
    }
}



/* Ÿ�̸� ����
 * 
 * ĵ������ Timer ��ũ��Ʈ �ֱ�
 * Timer���� �������� ���� 2�� ���� (��, ��)
 * �ν����Ϳ��� �ð����� ����
 * UI���� ���Ž� - �ؽ�Ʈ�� 3�� ����
 * ���� ��,��,���ӿ���
 * Timer�� ����ְ� ��Ʈ, ������, ��ġ ���� ����
 * ���ӿ����ؽ�Ʈ �ʿ� ���� �� ��Ʈ�� ����� �ذᰡ��
*/