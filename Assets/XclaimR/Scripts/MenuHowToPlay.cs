using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuHowToPlay : MonoBehaviour
{
    public Text htp;
    private int fontSize;
    private Color tempColor;
    private AudioSource audio;
    //public AudioClip Mysound;

    void Start()
    {
        tempColor = htp.color;
        fontSize = htp.fontSize;
        //audio = GetComponent<AudioSource>();
    }

    void OnMouseEnter()
    {
        htp.fontSize = fontSize + 5;
        //audio.Play();
    }

    void OnMouseExit()
    {
        htp.fontSize = fontSize;
    }


    void OnMouseUp()
    {
        SceneManager.LoadScene("HowToPlay");
    }
}