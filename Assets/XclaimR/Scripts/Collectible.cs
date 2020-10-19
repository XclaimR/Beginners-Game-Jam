using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    GameObject gameManager;
    GlobalVariables globalV;
    private AudioSource collectSound;

    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        globalV = gameManager.GetComponent<GlobalVariables>();
        collectSound = GameObject.Find("onCollect").GetComponent<AudioSource>();
    }
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            Debug.Log("Collected");
            collectSound.Play();
            globalV.collected++;
            GameObject reactorPiece = GameObject.Find(gameObject.GetComponent<SpriteRenderer>().sprite.name);
            reactorPiece.GetComponent<SpriteRenderer>().color = Color.white;
            Debug.Log(gameObject.GetComponent<SpriteRenderer>().sprite.name);
            Destroy(gameObject);
        }
    }
}
