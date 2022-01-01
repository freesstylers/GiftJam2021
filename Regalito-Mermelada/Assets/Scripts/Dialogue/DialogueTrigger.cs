using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public DialogueUI dialogue;

    public void TriggerDialogue(DialogueManager m)
    {
        m.StartDialogue(dialogue);
    }
}
