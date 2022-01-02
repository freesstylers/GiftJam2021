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
    [HideInInspector]
    DialogueManager dialogueMan = null;

    [HideInInspector]
    public GlowObjectCmd glowControl;
    [HideInInspector]
    public DialogueTrigger dialogueTrigger;

    public bool displaying = false;
    public bool canInteract = true;

    public DialogueAction[] actions;

    public string flag = "";

    [HideInInspector]
    public Interact player = null;

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

        if (!canInteract || !player)
            TurnOff();
        else
            TurnOn();

        if(player)
            player.RefreshState();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            player = other.gameObject.GetComponent<Interact>();

            player.currentInteractable = this;

            RefreshState();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            glowControl.Exit();

            if (player != null)
            {
                player.TurnOff();

                if (player.currentInteractable && player.currentInteractable == this.gameObject)
                    player.currentInteractable = null;

                player = null;
            }
        }
    }
}
