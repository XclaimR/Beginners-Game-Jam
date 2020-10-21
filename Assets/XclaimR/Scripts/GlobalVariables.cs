using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GlobalVariables : MonoBehaviour
{
    [SerializeField] public float enemySpeed = 0.5f;
    [SerializeField] public float playerSpeed = 5f;
    [SerializeField] public float playerDefaultSpeed = 5f;
    [SerializeField] public Color lightColor;
    [SerializeField] public int chances = 2;
    public float detectRate = 2f;
    public float nextDetectTime = 0f;
    public float coolDownRate = 20f;
    public float nextCoolDownTime = -1f;
    public int collected = 0;
    public int totalCollectibles;

    void Start()
    {
        enemySpeed = 0.5f;
        playerSpeed = 5f;
        //lightColor = new Color(0.6320754f, 0.6320754f, 0.6320754f);
        if(SceneManager.GetActiveScene().name == "Planet 1")
        {
            lightColor = new Color(0.7924528f, 0.2527757f, 0.1308295f);
        }
        if (SceneManager.GetActiveScene().name == "Planet 2")
        {
            lightColor = new Color(0.6320754f, 0.6320754f, 0.6320754f);
        }
        if (SceneManager.GetActiveScene().name == "Planet 3")
        {
            lightColor = new Color(0.6320754f, 0.6320754f, 0.6320754f);
        }

        totalCollectibles = GameObject.FindGameObjectsWithTag("Collectible").Length;
    }

    public void NormalAlert()
    {
        GameObject.Find("DetectionSound").GetComponent<AudioSource>().Stop();
        Debug.Log("Normal");
        chances = 2;
        enemySpeed = 0.5f;
        playerSpeed = 5f;
        if (SceneManager.GetActiveScene().name == "Planet 1")
        {
            lightColor = new Color(0.7924528f, 0.2527757f, 0.1308295f);
        }
        if (SceneManager.GetActiveScene().name == "Planet 2")
        {
            lightColor = new Color(0.6320754f, 0.6320754f, 0.6320754f);
        }
        if (SceneManager.GetActiveScene().name == "Planet 3")
        {
            lightColor = new Color(0.6320754f, 0.6320754f, 0.6320754f);
        }
        //lightColor = new Color(0.6320754f, 0.6320754f, 0.6320754f);
        //totalCollectibles = GameObject.FindGameObjectsWithTag("Collectible").Length;
    }

    public void RedAlert()
    {
        GameObject.Find("DetectionSound").GetComponent<AudioSource>().Play();
        chances--;
        if(chances == 0)
        {
            Debug.Log("Game Over");
            GameObject.Find("DetectionSound").GetComponent<AudioSource>().Stop();
            GameOver();
        }
        enemySpeed = 2f;
        playerSpeed = 8f;
        lightColor = new Color(0.7924528f, 0f, 0f);
    }

    public void SetPlayerMoveSpeed(float amount)
    {
        playerSpeed = amount;
    }

    public float GetPlayerMoveSpeed()
    {
        return playerSpeed;
    }

    public float GetPlayerDefaultSpeed()
    {
        return playerDefaultSpeed;
    }

    void GameOver()
    {
        Lives lives = gameObject.GetComponent<Lives>();
        lives.RemoveLives();
    }
}
