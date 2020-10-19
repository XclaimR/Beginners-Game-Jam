using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lives : MonoBehaviour
{
    [SerializeField] int lives = 3;

    public GameObject message;
    private AudioSource playerCaught;

    void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        lives = PlayerPrefs.GetInt("Lives");
        playerCaught = GameObject.Find("caughtSound").GetComponent<AudioSource>();
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
        message.GetComponent<Text>().enabled = true;
        playerCaught.Play();
        GameObject player = GameObject.Find("Orb");
        player.GetComponent<PlayerMovement>().enabled = false;
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach(GameObject enemy in enemies)
        {
            enemy.GetComponent<EnemyMovement>().enabled = false;
        }
        Invoke("LoadScene", 2);
        
    }

    public void LoadScene()
    {
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