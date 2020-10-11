using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void LoadStartScene()
    {
        // SceneManager.LoadScene("Start Menu"); CAN DO THIS
        SceneManager.LoadScene(0);
    }

    public void LoadGameOverScreen()
    {
        SceneManager.LoadScene("GameOverScreen");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
