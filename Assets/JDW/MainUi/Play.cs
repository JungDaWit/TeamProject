using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Play : MonoBehaviour
{
  
    public void GamePlay()
    {
        //Debug.Log("���ӽ���"); //TO DO : ���� �� �����ߵ�
        SceneManager.LoadScene("map");
    }
}
