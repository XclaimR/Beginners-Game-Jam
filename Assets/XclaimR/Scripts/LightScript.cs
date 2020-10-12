using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class LightScript : MonoBehaviour
{
    public GameObject fl_point;
    public EnemyMovement eMove;
    bool isTurn = true;
    Light2D lt;
    GameObject gameManager;
    GlobalVariables globalV;
    public float detectRate = 5f;
    float nextDetectTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
        lt = GetComponent<Light2D>();
        gameManager = GameObject.Find("GameManager");
        globalV = gameManager.GetComponent<GlobalVariables>();
    }

    void Update()
    {
        lt.color = globalV.lightColor;
        if (!eMove.MoveRight && isTurn && !eMove.isPause)
        {
            transform.Rotate(180,0 , 0);
            isTurn = false;
        }
        if (eMove.MoveRight && !isTurn && !eMove.isPause)
        {
            transform.Rotate(180, 0, 0);
            isTurn = true;
        }
        transform.position = fl_point.transform.position;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            //Destroy(collider.gameObject);
            if (Time.time >= nextDetectTime)
            {
                nextDetectTime = Time.time + 1 / detectRate;
                globalV.RedAlert();
               // Debug.Log("Detected");
            }
        }

        if(collider.gameObject.tag == "Transform")
        {
            Debug.Log("Detected");
            eMove.isPause = true;
            Invoke("eMove.Resume", 1);
        }
    }
    
}
