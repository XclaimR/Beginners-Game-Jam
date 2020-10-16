using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class LightScript : MonoBehaviour
{
    GameObject fl_point;
    EnemyMovement eMove;
    public GameObject Enemy;
    bool isTurn = true;
    Light2D lt;
    GameObject gameManager;
    GlobalVariables globalV;
    bool detected = false;

    // Start is called before the first frame update
    void Start()
    {
        fl_point = Enemy.transform.GetChild(4).gameObject;
        eMove = Enemy.GetComponent<EnemyMovement>();
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

        if (Time.time > globalV.nextCoolDownTime && detected == true)
        {
            globalV.NormalAlert();  
            detected = false;
        }
        //Debug.Log(nextCoolDownTime);
    }

    void OnTriggerStay2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            //Destroy(collider.gameObject);
            if (Time.time >= globalV.nextDetectTime)
            {
                globalV.nextDetectTime = Time.time + globalV.detectRate;
                globalV.nextCoolDownTime = Time.time + globalV.coolDownRate;
                detected = true;
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
