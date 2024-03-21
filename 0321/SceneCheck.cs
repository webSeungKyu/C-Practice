using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneCheck : MonoBehaviour
{
    public string SceneName;

    

    public void ChangeScene()
    {
        SceneManager.LoadScene(SceneName);
        Debug.Log($"{SceneName} æ¿¿∏∑Œ ¿Ãµø..");
    }

}
