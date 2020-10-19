using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioStart : MonoBehaviour
{
    // Start is called before the first frame update
    private static AudioStart instance = null;
    public AudioSource audio;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            return;
        }
        if (instance == this) return;
        //Destroy(gameObject);
    }

    void Start()
    {
        audio = GetComponent<AudioSource>();
        audio.Play();
    }
}