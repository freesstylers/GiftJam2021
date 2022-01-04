using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public struct DialogueAction
{
    public enum Type { FLAGOFF, FLAGON, GIVEITEM, NEXTDIALOGUE, FLAGCHANGE, DESTROYOBJECT, ACTIVATEOBJECT, DEACTIVATECOMPONENT, FUNDIDOANEGRO, TPTO };
    public Type action;
    public string flag;
    public string item;
    public GameObject[] gO;
    public Component[] components;
    public Vector3 tpTo;
    public DialogueUI dialogue;
}

[System.Serializable]
public class ActionStorage : SerializableDictionary.Storage<DialogueAction[]> { }

[System.Serializable]
public class ActionDictionary : SerializableDictionary<string, DialogueAction[], ActionStorage> { }

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

    public ActionDictionary actions;

    public string flag = "";
    public bool invert = false;

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
        if (actions.ContainsKey(flag))
        {
            foreach (DialogueAction action in actions[flag])
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
                    case DialogueAction.Type.NEXTDIALOGUE:
                        dialogueTrigger.NextDialogue();
                        flag = action.flag;
                        break;
                    case DialogueAction.Type.FLAGCHANGE:
                        flag = action.flag;
                        break;
                    case DialogueAction.Type.DESTROYOBJECT:
                        if (action.gO.Length > 0)
                        {
                            foreach (GameObject g in action.gO)
                                g.SetActive(false);
                        }
                        break;
                    case DialogueAction.Type.ACTIVATEOBJECT:
                        if (action.gO.Length > 0)
                        {
                            foreach (GameObject g in action.gO)
                                g.SetActive(true);
                        }
                        break;
                    case DialogueAction.Type.DEACTIVATECOMPONENT:
                        if (action.components.Length > 0)
                        {
                            foreach (Component c in action.components)
                                Destroy(c);
                        }
                        break;
                    case DialogueAction.Type.FUNDIDOANEGRO:
                        FindObjectOfType<DialogueManager>().callFadeToBlack(action.dialogue);
                        break;
                    case DialogueAction.Type.TPTO:
                        PlayerMovement p = FindObjectOfType<PlayerMovement>();
                        p.canMove = false;
                        p.gameObject.transform.position = action.tpTo;
                        p.canMove = true;      
                        break;
                    default:
                        break;
                }       
            }
        }

        displaying = false;
        dialogueMan.currentObject = null;

        RefreshState();
    }

    void RefreshState()
    {
        canInteract = FlagManager.GetKey(flag);

        if (invert)
            canInteract = !canInteract;

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
