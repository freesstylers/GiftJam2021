using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    DialogueManager dialogueMan = null;

    public GlowObjectCmd glowControl;
    public DialogueTrigger dialogueTrigger;


    public bool displaying = false;

    // Start is called before the first frame update
    void Start()
    {
        dialogueMan = FindObjectOfType<DialogueManager>();
        glowControl = gameObject.GetComponent<GlowObjectCmd>();
        dialogueTrigger = gameObject.GetComponent<DialogueTrigger>();
    }

    public void TriggerDialogue()
    {
        if (!displaying && dialogueMan && dialogueTrigger)
        {
            displaying = true;
            dialogueTrigger.TriggerDialogue(dialogueMan);
        }

    }

    public void TurnOff()
    {
        glowControl.TurnOff();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
