using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Load : MonoBehaviour
{
    public Timer timer;


    void Start()
    {
        float Timer = PlayerPrefs.GetFloat("Timer", 50f);
        Debug.Log($"���� �ð� �ҷ�����{Timer}");

        if(timer != null)
        {
            timer.time = Timer;
        }
        else
        {
            Debug.LogError("Ÿ�̸� ���� �� ��");
        }

    
    }
}
