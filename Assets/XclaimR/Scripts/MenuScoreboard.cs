﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuScoreboard : MonoBehaviour
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
        audio = GameObject.Find("MenuSound").GetComponent<AudioSource>();
    }

    void OnMouseEnter()
    {
        start.fontSize = fontSize + 5;
        audio.Play();
    }

    void OnMouseExit()
    {
        start.fontSize = fontSize;
    }


    void OnMouseUp()
    {
        SceneManager.LoadScene("Scoreboard");
    }
}