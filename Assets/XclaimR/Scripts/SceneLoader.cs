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

    public void LoadGameOverScene()
    {
        SceneManager.LoadScene("GameOverScene");
    }

    public void LoadRestartScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex - 1);
    }

    public void LoadOptionsScene()
    {
        SceneManager.LoadScene("OptionsScene");
    }

    public void LoadHowToPlayScene()
    {
        SceneManager.LoadScene("HowToPlayScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
