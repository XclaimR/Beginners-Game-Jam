using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioDestroy : MonoBehaviour
{
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "Planet 1")
        {
            Destroy(GameObject.Find("MainSound"));
            //GameObject.Find("MainSound").GetComponent<AudioSource>().Stop();
        }
        if (SceneManager.GetActiveScene().name == "Planet 2")
        {
            Destroy(GameObject.Find("Planet1MainSound"));
        }
        if (SceneManager.GetActiveScene().name == "Planet 3")
        {
            Destroy(GameObject.Find("Planet2MainSound"));
        }
        if (SceneManager.GetActiveScene().name == "GameOver" || SceneManager.GetActiveScene().name == "Victory")
        {
            GameObject.Find("MainSound").GetComponent<AudioSource>().Play();
        }
    }
}
