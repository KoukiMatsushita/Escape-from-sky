using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneScript : MonoBehaviour
{
  

    public void ChangeScene(string sceneName)
    {
        //�D���ȃV�[���ɔ�ԏ����B
        SceneManager.LoadScene(sceneName);
    }
}