using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveTimer : MonoBehaviour
{
    public Timer timer;

    public void SaveTi()
    {
        if (timer != null)
        {
            PlayerPrefs.SetFloat("Timer", timer.time);
            Debug.Log($"{timer.time} Ÿ�̸� ����");
        }
        else
        {
            Debug.LogError("�������");
        }
    }
        
}
