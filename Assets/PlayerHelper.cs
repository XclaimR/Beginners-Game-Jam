using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHelper : MonoBehaviour
{
    public bool isDone = true;
    public bool isClose = false;
    GameObject player;

    public Dialogue dialogue;
    private Dialogue tempDialogue;
    
    private AudioSource dialogueOpen;
    private AudioSource dialogueClose;

    //public void TriggerDialogue()
    //{

    //}

    void Start()
    {
        dialogueOpen = GameObject.Find("dialogueOpen").GetComponent<AudioSource>();
        dialogueClose = GameObject.Find("dialogueClose").GetComponent<AudioSource>();
        tempDialogue = dialogue;
        
    }

    void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            //player = collider.gameObject;
            collider.gameObject.transform.Find("Canvas").gameObject.SetActive(true);
            if (Input.GetKey(KeyCode.E) && isDone && !isClose)
            {
                collider.gameObject.GetComponent<PlayerMovement>().playerWalk.Stop();
                gameObject.transform.GetChild(0).gameObject.SetActive(true);
                collider.gameObject.GetComponent<PlayerMovement>().enabled = false;
                FindObjectOfType<DialogueManager>().StartDialogue(tempDialogue);
                dialogueOpen.Play();
                isDone = false;
                //Invoke("Close", 2);
                Debug.Log(collider.gameObject.transform.GetChild(0).name);
                
            }

            if((Input.GetKey(KeyCode.E) || Input.GetKey(KeyCode.Return)) && !isDone && isClose)
            {
                //Invoke("Done", 2);
                isClose = false;
                isDone = true;
                dialogueClose.Play();
                gameObject.transform.GetChild(0).gameObject.SetActive(false);
                collider.gameObject.GetComponent<PlayerMovement>().enabled = true;
            }
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            Debug.Log("Exited");
            collider.gameObject.transform.Find("Canvas").gameObject.SetActive(false);
            isDone = true;
            isClose = false;
        }

    }
}
