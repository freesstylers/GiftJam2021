using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    public InteractableObject currentInteractable = null;

    public GameObject mecano = null;

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

                    currentInteractable.TurnOff();

                    mecano.SetActive(false);
                }
                catch (System.Exception e)
                {
                    Debug.Log(e);
                }
            }
        }
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Object")
        {
            currentInteractable = other.GetComponent<InteractableObject>();
            mecano.SetActive(currentInteractable.canInteract);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Object" && currentInteractable.gameObject == other.gameObject)
        {
            currentInteractable = null;
            mecano.SetActive(false);
        }
    }
}
