using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lives : MonoBehaviour
{
    [SerializeField] float lives = 3;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public float GetLives()
    {
        return lives;
    }

    public void RemoveLives()
    {
        lives--;
        FindObjectOfType<SceneLoader>().LoadGameOverScreen();
    }
}