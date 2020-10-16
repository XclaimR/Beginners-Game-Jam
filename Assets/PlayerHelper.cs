using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHelper : MonoBehaviour
{
    bool isDone = true;
    bool isClose = false;

    void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Helper")
        {
            gameObject.transform.Find("Canvas").gameObject.SetActive(true);
            if (Input.GetKey(KeyCode.E) && isDone && !isClose)
            {
                isDone = false;
                Invoke("Close", 2);
                Debug.Log(collider.gameObject.transform.GetChild(0).name);
                collider.gameObject.transform.GetChild(0).gameObject.SetActive(true);
                gameObject.GetComponent<PlayerMovement>().enabled = false;
            }

            if(Input.GetKey(KeyCode.E) && !isDone && isClose)
            {
                Invoke("Done", 2);
                isClose = false;
                collider.gameObject.transform.GetChild(0).gameObject.SetActive(false);
                gameObject.GetComponent<PlayerMovement>().enabled = true;
            }
        }
        else
        {
            gameObject.transform.Find("Canvas").gameObject.SetActive(false);
        }
    }

    void Close()
    {
        isClose = true;
    }

    void Done()
    {
        isDone = true;
    }
}
