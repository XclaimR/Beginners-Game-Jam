using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuCredits : MonoBehaviour
{
    public Text credits;
    private int fontSize;
    private Color tempColor;
    private AudioSource audio;
    //public AudioClip Mysound;

    void Start()
    {
        tempColor = credits.color;
        fontSize = credits.fontSize;
        audio = GameObject.Find("MenuSound").GetComponent<AudioSource>();
    }

    void OnMouseEnter()
    {
        credits.fontSize = fontSize + 5;
        audio.Play();
    }

    void OnMouseExit()
    {
        credits.fontSize = fontSize;
    }


    void OnMouseUp()
    {
        SceneManager.LoadScene("Credits");
    }
}