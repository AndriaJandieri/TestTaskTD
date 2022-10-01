using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadSceneWithIndex(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void ExitGame()
    {
        Debug.Log("Exit Game Clicked...");
        Application.Quit();
    }
}
