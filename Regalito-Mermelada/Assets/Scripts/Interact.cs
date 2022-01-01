using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    public InteractableObject currentInteractable = null;

    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(currentInteractable)
            {
                try
                {
                    currentInteractable.TriggerDialogue();
                }
                catch (System.Exception e)
                {
                    Debug.Log(e);
                }

                currentInteractable.TurnOff();
            }
        }
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Object")
        {
            currentInteractable = other.GetComponent<InteractableObject>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Object" && currentInteractable.gameObject == other.gameObject)
        {
            currentInteractable = null;
        }
    }
}
