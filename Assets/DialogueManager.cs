using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    private Queue<string> sentences;
    public Text dialogueText;
    bool isTyping = false;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    void Update()
    {
        if ((Input.GetKey(KeyCode.Return) || Input.GetKey(KeyCode.E)) && isTyping == false)
        {
            DisplayNextSentence();
        }
    }

    public void StartDialogue(Dialogue dialogue)
    {
        Debug.Log("Starting Dialogue");
        sentences.Clear();

        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialogue();
            FindObjectOfType<PlayerHelper>().isClose = true;
            FindObjectOfType<PlayerHelper>().isDone = false;
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        isTyping = true;
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
        isTyping = false;
    }

    void EndDialogue()
    {
        Debug.Log("End of Conversation");
    }
    
}
