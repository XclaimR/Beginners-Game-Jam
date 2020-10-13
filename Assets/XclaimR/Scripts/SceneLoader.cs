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
        Debug.Log("Entered");
        gameObject.GetComponent<Lives>().SetLives();
        PlayerPrefs.SetInt("Lives", gameObject.GetComponent<Lives>().GetLives());
        SceneManager.LoadScene("GameOver");
    }

    public void LoadRestartScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    public void LoadOptionsScene()
    {
        SceneManager.LoadScene("Options");
    }

    public void LoadHowToPlayScene()
    {
        SceneManager.LoadScene("HowToPlay");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
