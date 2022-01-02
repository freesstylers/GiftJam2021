using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text dialogueText;
    private Queue<string> sentences;

    public InteractableObject currentObject = null;

    string func = "";
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
        
        if (dialogue.name != "")
        {
            dialogueText.transform.parent.GetChild(0).gameObject.SetActive(true);

        }

        if (dialogue.function)
            func = dialogue.functionName;

        dialogueText.color = Color.white;
        FindObjectOfType<PlayerMovement>().canMove = false;
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
        FindObjectOfType<PlayerMovement>().canMove = true;
        dialogueText.transform.parent.gameObject.SetActive(false);

        if (currentObject)
        {
            currentObject.DialogueEnd();
            currentObject = null;
        }

        if (func != "")
        {
            switch (func)
            {
                case "Trees":
                    ChangeToTrees();
                    break;
                default:
                    break;
            }
        }
    }

    void ChangeToTrees()
    {
        SceneManager.LoadScene("TreeRoad");
    }
}
