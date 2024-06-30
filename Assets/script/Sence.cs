using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneScript : MonoBehaviour
{
  

    public void ChangeScene(string sceneName)
    {
        //好きなシーンに飛ぶ処理。
        SceneManager.LoadScene(sceneName);
    }
}