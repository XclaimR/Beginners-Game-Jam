using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalVariables : MonoBehaviour
{
    [SerializeField] public float enemySpeed = 0.5f;
    [SerializeField] public float playerSpeed = 5f;
    [SerializeField] public Color lightColor;
    [SerializeField] public int chances = 2;

    void Start()
    {
        enemySpeed = 0.5f;
        playerSpeed = 5f;
        lightColor = new Color(0.6320754f, 0.6320754f, 0.6320754f);
    }

    public void RedAlert()
    {
        chances--;
        if(chances == 0)
        {
            GameOver();
        }
        enemySpeed = 2f;
        playerSpeed = 8f;
        lightColor = new Color(0.7924528f, 0f, 0f);
    }

    void GameOver()
    {
        SceneLoader sceneLoader = gameObject.GetComponent<SceneLoader>();
        sceneLoader.LoadGameOverScreen();
    }
}
