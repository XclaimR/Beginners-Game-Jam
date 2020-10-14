using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetTime : MonoBehaviour
{
    public Text time;
    public float runTime;

    void Awake()
    {
        runTime = PlayerPrefs.GetFloat("Runtime");
        GameObject timer = GameObject.Find("Timer");
        time.text = timer.GetComponent<Timer>().DisplayTime(runTime);
    }

}
