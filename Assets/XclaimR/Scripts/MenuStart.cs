using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuStart : MonoBehaviour
{
    public Text start;
    private int fontSize;
    private Color tempColor;
    private AudioSource audio;
    //public AudioClip Mysound;

    void Start()
    {
        tempColor = start.color;
        fontSize = start.fontSize;
        //audio = GetComponent<AudioSource>();
    }

    void OnMouseEnter()
    {
        start.fontSize = fontSize + 5;
        //audio.Play();
    }

    void OnMouseExit()
    {
        start.fontSize = fontSize;
    }


    void OnMouseUp()
    {
        GameObject timer = GameObject.Find("Timer");
        timer.GetComponent<Timer>().startTime = Time.time;
        Debug.Log("Start Time : " + timer.GetComponent<Timer>().DisplayTime(timer.GetComponent<Timer>().startTime));
        DontDestroyOnLoad(timer);
        SceneManager.LoadScene("MainScene");
    }
}