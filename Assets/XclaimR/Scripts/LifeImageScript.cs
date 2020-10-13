using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeImageScript : MonoBehaviour
{
    GameObject lives;
    GameObject gameManager;
    GlobalVariables globalV;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        globalV = gameManager.GetComponent<GlobalVariables>();
        lives = gameObject;
        Debug.Log(lives.name);
    }

    void Update()
    {
        if (PlayerPrefs.GetInt("Lives") == 3)
        {
            lives.transform.GetChild(2).gameObject.SetActive(true);
            lives.transform.GetChild(1).gameObject.SetActive(true);
            lives.transform.GetChild(0).gameObject.SetActive(true);
        }
        if (PlayerPrefs.GetInt("Lives") == 2)
        {
            lives.transform.GetChild(2).gameObject.SetActive(false);
            lives.transform.GetChild(1).gameObject.SetActive(true);
            lives.transform.GetChild(0).gameObject.SetActive(true);
        }
        if (PlayerPrefs.GetInt("Lives") == 1)
        {
            lives.transform.GetChild(2).gameObject.SetActive(false);
            lives.transform.GetChild(1).gameObject.SetActive(false);
            lives.transform.GetChild(0).gameObject.SetActive(true);
        }
    }
}
