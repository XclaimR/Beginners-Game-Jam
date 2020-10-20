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

    void Start()
    {
        bossBlock = GameObject.Find("BossBlock");
    }

    void Update()
    {
        if (bossStart)
        {
            if (count == 0)
            {
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
    }


}
