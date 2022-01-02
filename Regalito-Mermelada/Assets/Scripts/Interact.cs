using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    public InteractableObject currentInteractable = null;

    public GameObject mecano = null;

    public bool isTalking = false;

    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(currentInteractable && !isTalking)
            {
                try
                {
                    currentInteractable.TriggerDialogue();

                    currentInteractable.TurnOff();

                    mecano.SetActive(false);

                    isTalking = true;
                }
                catch (System.Exception e)
                {
                    Debug.Log(e);
                }
            }
        }
    }

    public void RefreshState()
    {
        bool canInteract = currentInteractable && currentInteractable.canInteract;

        if (!canInteract)
            TurnOff();
        else
            TurnOn();
    }

    public void TurnOn()
    {
        mecano.SetActive(currentInteractable.canInteract);

        isTalking = false;
    }

    public void TurnOff()
    {
        currentInteractable = null;
        mecano.SetActive(false);

        isTalking = false;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Object")
        {
            //TurnOn();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Object" && (!currentInteractable || currentInteractable.gameObject == other.gameObject))
        {
            //TurnOff();
        }
    }
}
