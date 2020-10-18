using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryStart : MonoBehaviour
{
    public Dialogue dialogue;

    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<StoryDialogueManager>().StartDialogue(dialogue);
    }
    
}
