using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Load : MonoBehaviour
{
    public float TimerNextScene; // ���� ������ ����� �÷��̾� ü��


    void Start()
    {
        LoadTimer();

        Debug.Log($"Ÿ�̸� �ҷ�����");
    }

    void LoadTimer()
    {

        TimerNextScene = PlayerPrefs.GetFloat("Timer");
    }


    public float Timer
    {
        get { return TimerNextScene; }
    }
}
