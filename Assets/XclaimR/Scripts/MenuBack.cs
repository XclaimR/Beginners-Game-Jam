using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuBack : MonoBehaviour
{
    public Text back;
    private int fontSize;
    private Color tempColor;
    private AudioSource audio;
    //public AudioClip Mysound;

    void Start()
    {
        tempColor = back.color;
        fontSize = back.fontSize;
        //audio = GetComponent<AudioSource>();
    }

    void OnMouseEnter()
    {
        back.fontSize = fontSize + 5;
        //audio.Play();
    }

    void OnMouseExit()
    {
        back.fontSize = fontSize;
    }


    void OnMouseUp()
    {
        SceneManager.LoadScene("MainMenu");
    }
}