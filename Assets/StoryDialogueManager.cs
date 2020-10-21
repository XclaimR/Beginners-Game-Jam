using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryDialogueManager : MonoBehaviour
{
    private Queue<string> sentences;
    public Text dialogueText;
    private AudioSource typeSound;

    // Start is called before the first frame update
    void Start()
    {
        typeSound = GameObject.Find("TypeSound").GetComponent<AudioSource>();
        sentences = new Queue<string>();
    }

    void Update()
    {
        DisplayNextSentence();
      
    }

    public void StartDialogue(Dialogue dialogue)
    {
        Debug.Log("Starting Dialogue");
        sentences.Clear();
        typeSound.Play();
        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
        
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
        GameObject.Find("Canvas").transform.GetChild(1).gameObject.SetActive(true);
        typeSound.Stop();
    }

    void EndDialogue()
    {
        
        Debug.Log("End of Conversation");
    }
}
