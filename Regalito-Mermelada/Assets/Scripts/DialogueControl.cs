using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueControl : MonoBehaviour
{
    public DialogueUI d;
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(d);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            FindObjectOfType<DialogueManager>().DisplayNextDialogue();
        }
    }
}
