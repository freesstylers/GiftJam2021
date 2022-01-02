using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct DialogueAction
{
    public enum Type { FLAGOFF, FLAGON, GIVEITEM };

    public string flag;
    public string item;
    public Type action;

}

public class InteractableObject : MonoBehaviour
{
    DialogueManager dialogueMan = null;

    public GlowObjectCmd glowControl;
    public DialogueTrigger dialogueTrigger;

    public bool displaying = false;
    public bool canInteract = true;

    public DialogueAction[] actions;

    public string flag = "";

    // Start is called before the first frame update
    void Start()
    {
        dialogueMan = FindObjectOfType<DialogueManager>();
        glowControl = gameObject.GetComponent<GlowObjectCmd>();
        dialogueTrigger = gameObject.GetComponent<DialogueTrigger>();
    }

    public void TriggerDialogue()
    {
        if (canInteract && !displaying && dialogueMan && dialogueTrigger)
        {
            displaying = true;
            dialogueTrigger.TriggerDialogue(dialogueMan);
            dialogueMan.currentObject = this;
        }
    }

    public void TurnOff()
    {
        glowControl.TurnOff();
        canInteract = false;
    }

    public void TurnOn()
    {
        glowControl.TurnOn();
        canInteract = true;
    }

    public void DialogueEnd()
    {
        foreach (DialogueAction action in actions)
        {
            switch (action.action)
            {
                case DialogueAction.Type.FLAGOFF:
                    FlagManager.SetKey(action.flag, false);
                    break;
                case DialogueAction.Type.FLAGON:
                    FlagManager.SetKey(action.flag, true);
                    break;
                case DialogueAction.Type.GIVEITEM:
                    break;
                default:
                    break;
            }
        }

        displaying = false;
        dialogueMan.currentObject = null;

        RefreshState();
    }

    void RefreshState()
    {
        canInteract = FlagManager.GetKey(flag);

        if (!canInteract)
            TurnOff();
        else
            TurnOn();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            RefreshState();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            glowControl.Exit();
        }
    }
}
