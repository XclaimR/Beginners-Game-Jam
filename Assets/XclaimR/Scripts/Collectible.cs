using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    GameObject gameManager;
    GlobalVariables globalV;

    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        globalV = gameManager.GetComponent<GlobalVariables>();
    }
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            Debug.Log("Collected");
            globalV.collected++;
            Destroy(gameObject);
        }
    }
}
