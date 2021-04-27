using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    int currentBuildIndex;

    void Start()
    {
        currentBuildIndex = SceneManager.GetActiveScene().buildIndex;
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("Game");
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(currentBuildIndex + 1);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
