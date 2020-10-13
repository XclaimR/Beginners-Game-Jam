using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lives : MonoBehaviour
{
    [SerializeField] int lives = 3;

    void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        lives = PlayerPrefs.GetInt("Lives");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetLives()
    {
        lives = 3;
    }

    public int GetLives()
    {
        return lives;
    }

    public void RemoveLives()
    {
        lives--;
        PlayerPrefs.SetInt("Lives",lives);
        if (GetLives() <= 0)
        {
            FindObjectOfType<SceneLoader>().LoadGameOverScene();
        }
        else
        {
            FindObjectOfType<SceneLoader>().LoadRestartScene();
        }
    }
}