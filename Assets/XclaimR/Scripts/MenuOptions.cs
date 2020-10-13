using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuOptions : MonoBehaviour
{
    public Text options;
    private int fontSize;
    private Color tempColor;
    private AudioSource audio;
    //public AudioClip Mysound;

    void Start()
    {
        tempColor = options.color;
        fontSize = options.fontSize;
        //audio = GetComponent<AudioSource>();
    }

    void OnMouseEnter()
    {
        options.fontSize = fontSize + 5;
        //audio.Play();
    }

    void OnMouseExit()
    {
        options.fontSize = fontSize;
    }


    void OnMouseUp()
    {
        SceneManager.LoadScene("Options");
    }
}