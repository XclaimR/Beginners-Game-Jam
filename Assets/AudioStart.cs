using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioStart : MonoBehaviour
{
    // Start is called before the first frame update
    private static AudioStart instance = null;
    public AudioSource audio;

    void Awake()
    {
        DontDestroyOnLoad(this);
        if (instance == null)
        {
            instance = this;
        }
        else{
            Destroy(gameObject);
        }
    }

    //void Start()
    //{
    //    audio = GetComponent<AudioSource>();
    //    audio.Play();
    //}

    
    
}