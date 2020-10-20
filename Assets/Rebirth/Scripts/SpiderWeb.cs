using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderWeb : MonoBehaviour
{
    float speedDecay = 2f;
    
    

    private void OnTriggerEnter2D(Collider2D collider)
    {
        GlobalVariables GlobalVarSpeed = FindObjectOfType<GlobalVariables>();
        if (collider.gameObject.tag == "Player")
        {
            GlobalVarSpeed.SetPlayerMoveSpeed(speedDecay);
            Debug.Log("Stuck in web");
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        GlobalVariables GlobalVarSpeed = FindObjectOfType<GlobalVariables>();
        GlobalVarSpeed.SetPlayerMoveSpeed(GlobalVarSpeed.GetPlayerDefaultSpeed());
        Debug.Log("Out of web");
    }
}
