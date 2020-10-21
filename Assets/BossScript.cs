using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;

public class BossScript : MonoBehaviour
{
    public bool bossStart = false;
    int count = 0;
    GameObject bossBlock;
    AudioSource bossGrowl;

    GameObject gameManager;
    GlobalVariables globalV;

    GameObject spiderExit;

    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        globalV = gameManager.GetComponent<GlobalVariables>();
        bossBlock = GameObject.Find("BossBlock");
        bossGrowl = GameObject.Find("BossGrowl").GetComponent<AudioSource>();
        spiderExit = GameObject.Find("Spider_exit");
        spiderExit.SetActive(false);
    }

    void Update()
    {
        if (bossStart)
        {
            if (count == 0)
            {
                bossGrowl.Play();
                bossBlock.SetActive(true);
                GameObject.Find("CM vcam2").GetComponent<CinemachineVirtualCamera>().Priority = 11;
                GameObject.Find("CM vcam1").GetComponent<CinemachineVirtualCamera>().Priority = 1;
                count++;
            }
        }
        else
        {
            
            bossBlock.SetActive(false);
            GameObject.Find("CM vcam2").GetComponent<CinemachineVirtualCamera>().Priority = 1;
            GameObject.Find("CM vcam1").GetComponent<CinemachineVirtualCamera>().Priority = 11;
        }
        if(globalV.collected == globalV.totalCollectibles)
        {
            spiderExit.SetActive(true);
        }
    }


}
