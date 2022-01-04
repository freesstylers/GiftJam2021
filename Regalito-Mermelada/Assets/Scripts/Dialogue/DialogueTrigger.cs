using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public DialogueUI[] dialogue;

    public int currentDialogue = 0;

    public void TriggerDialogue(DialogueManager m)
    {
        m.StartDialogue(dialogue[currentDialogue]);
    }

    public void NextDialogue()
    {
        currentDialogue++;

        if(currentDialogue >= dialogue.Length)
            currentDialogue = dialogue.Length - 1;
    }
}
