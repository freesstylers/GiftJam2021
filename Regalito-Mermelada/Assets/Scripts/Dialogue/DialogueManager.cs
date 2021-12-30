using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text dialogueText;
    private Queue<string> sentences;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue( DialogueUI dialogue)
    {
        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        dialogueText.transform.parent.gameObject.SetActive(true);
        dialogueText.color = Color.white;
        DisplayNextDialogue();
    }

    public void DisplayNextDialogue()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string s = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(typeSentence(s));
        //dialogueText.text = s;
    }

    IEnumerator typeSentence(string s)
    {
        dialogueText.text = "";

        foreach (char letter in s.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.01f);
        }
    }

    public void EndDialogue()
    {
        dialogueText.transform.parent.gameObject.SetActive(false);
    }
}
