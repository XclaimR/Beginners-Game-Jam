using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalVariables : MonoBehaviour
{
    [SerializeField] public float enemySpeed = 0.5f;
    [SerializeField] public float playerSpeed = 5f;
    [SerializeField] public Color lightColor;
    [SerializeField] public int chances = 2;
    public float detectRate = 5f;
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
        //lightColor = new Color(0.7924528f, 0.2527757f, 0.1308295f);
        totalCollectibles = GameObject.FindGameObjectsWithTag("Collectible").Length;
    }

    public void NormalAlert()
    {
        Debug.Log("Normal");
        chances = 2;
        enemySpeed = 0.5f;
        playerSpeed = 5f;
        lightColor = new Color(0.7924528f, 0.2527757f, 0.1308295f);
        //lightColor = new Color(0.6320754f, 0.6320754f, 0.6320754f);
        //totalCollectibles = GameObject.FindGameObjectsWithTag("Collectible").Length;
    }

    public void RedAlert()
    {
        chances--;
        if(chances == 0)
        {
            Debug.Log("Game Over");
            GameOver();
        }
        enemySpeed = 2f;
        playerSpeed = 8f;
        lightColor = new Color(0.7924528f, 0f, 0f);
    }

    void GameOver()
    {
        Lives lives = gameObject.GetComponent<Lives>();
        lives.RemoveLives();
    }
}
