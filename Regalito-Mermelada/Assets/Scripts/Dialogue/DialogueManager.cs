using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text dialogueText;
    private Queue<Sentence> sentences;

    public AudioClip song1;
    public AudioClip song2;
    public AudioClip song3;
    public AudioSource audioSource;

    public InteractableObject currentObject = null;

    string func = "";
    
    //public GameObject Piso0;
    //public GameObject Piso1;
    //public GameObject Piso2;

    public GameObject Eurico;

    // Start is called before the first frame update
    void Start()
    {
        Eurico = GameObject.Find("Eurico");
        sentences = new Queue<Sentence>();
    }

    public void StartDialogue( DialogueUI dialogue)
    {
        sentences.Clear();

        foreach (Sentence sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        dialogueText.transform.parent.gameObject.SetActive(true);

        //if (dialogue.name != "")
        //{
        //    dialogueText.transform.parent.GetChild(0).gameObject.SetActive(true);
        //dialogueText.transform.parent.GetComponentInChildren<DialogueBoxSprite>().setSprite(dialogue);
        //}
        //else
        //    dialogueText.transform.parent.GetChild(0).gameObject.SetActive(false);

        if (dialogue.function)
            func = dialogue.functionName;
        else
            func = null;

        dialogueText.color = Color.white;
        FindObjectOfType<PlayerMovement>().canMove = false;
        DisplayNextDialogue();
    }

    public void DisplayNextDialogue()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        Sentence s = sentences.Dequeue();
        string aux = s.sentence;
        StopAllCoroutines();
        StartCoroutine(typeSentence(aux));

        if (s.sound != null)
        {
            GetComponent<AudioSource>().clip = s.sound;
            GetComponent<AudioSource>().Play();
        }

        if (s.icon != null)
        {
            dialogueText.transform.parent.GetChild(0).gameObject.SetActive(true);
            dialogueText.transform.parent.GetComponentInChildren<DialogueBoxSprite>().transform.GetComponent<Image>().sprite = s.icon;
        }
        else
        {
            dialogueText.transform.parent.GetChild(0).gameObject.SetActive(false);
        }
    }

    IEnumerator typeSentence(string s)
    {
        dialogueText.text = "";

        foreach (char letter in s.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.01f);
        }
    }

    public void EndDialogue()
    {
        StartCoroutine(delay());
    }

    IEnumerator delay()
    {
        FindObjectOfType<PlayerMovement>().canMove = true;
        dialogueText.transform.parent.gameObject.SetActive(false);

        yield return new WaitForSeconds(0.1f);

        if (currentObject)
        {
            currentObject.DialogueEnd();
            currentObject = null;
        }

        if (func != "")
        {
            switch (func)
            {
                case "Trees":
                    FindObjectOfType<PlayerMovement>().canMove = false;
                    ChangeToTrees();
                    break;
                case "BajarAscensor":
                    Eurico.GetComponent<CharacterController>().enabled = false;
                    Eurico.GetComponent<Interact>().currentInteractable.GetComponent<GlowObjectCmd>().running = false;
                    Eurico.GetComponent<Interact>().currentInteractable = null;
                    Eurico.GetComponent<Interact>().mecano.SetActive(false);
                    //Eurico.transform.localPosition = new Vector3(46.51377f, 1.52f, 48.44f);
                    Eurico.GetComponent<CharacterController>().enabled = true;
                    audioSource.clip = song3;
                    audioSource.Play();
                    break;
                case "SubirAscensor":
                    Eurico.GetComponent<CharacterController>().enabled = false;
                    Eurico.GetComponent<Interact>().currentInteractable.GetComponent<GlowObjectCmd>().running = false;
                    Eurico.GetComponent<Interact>().currentInteractable = null;
                    Eurico.GetComponent<Interact>().mecano.SetActive(false);
                    //Eurico.transform.localPosition = new Vector3(46.51377f, 1.52f, 48.44f);
                    Eurico.GetComponent<CharacterController>().enabled = true;
                    audioSource.clip = song1;
                    audioSource.Play();
                    break;
                case "BajarPiso0A":
                    Eurico.GetComponent<CharacterController>().enabled = false;
                    Eurico.GetComponent<Interact>().currentInteractable.GetComponent<GlowObjectCmd>().running = false;
                    Eurico.GetComponent<Interact>().currentInteractable = null;
                    Eurico.GetComponent<Interact>().mecano.SetActive(false);
                    Eurico.transform.localPosition = new Vector3(46.51377f, 1.52f, 48.44f);
                    Eurico.GetComponent<CharacterController>().enabled = true;
                    break;
                case "BajarPiso0B":
                    Eurico.GetComponent<CharacterController>().enabled = false;
                    Eurico.GetComponent<Interact>().currentInteractable.GetComponent<GlowObjectCmd>().running = false;
                    Eurico.GetComponent<Interact>().currentInteractable = null;
                    Eurico.GetComponent<Interact>().mecano.SetActive(false);
                    Eurico.transform.localPosition = new Vector3(-43.87f, 1.52f, 48.44f);
                    Eurico.GetComponent<CharacterController>().enabled = true;
                    break;
                case "SubirPiso1A":
                    Eurico.GetComponent<CharacterController>().enabled = false;
                    Eurico.GetComponent<Interact>().currentInteractable.GetComponent<GlowObjectCmd>().running = false;
                    Eurico.GetComponent<Interact>().currentInteractable = null;
                    Eurico.GetComponent<Interact>().mecano.SetActive(false);
                    Eurico.transform.localPosition = new Vector3(227.09f, 11.19f, 30.91f);
                    Eurico.GetComponent<CharacterController>().enabled = true;
                    break;
                case "SubirPiso1B":
                    Eurico.GetComponent<CharacterController>().enabled = false;
                    Eurico.GetComponent<Interact>().currentInteractable.GetComponent<GlowObjectCmd>().running = false;
                    Eurico.GetComponent<Interact>().currentInteractable = null;
                    Eurico.GetComponent<Interact>().mecano.SetActive(false);
                    Eurico.transform.localPosition = new Vector3(143.27f, 11.0f, 49.04f);
                    Eurico.GetComponent<CharacterController>().enabled = true;
                    break;
                case "BajarPiso1A":
                    Eurico.GetComponent<CharacterController>().enabled = false;
                    Eurico.GetComponent<Interact>().currentInteractable.GetComponent<GlowObjectCmd>().running = false;
                    Eurico.GetComponent<Interact>().currentInteractable = null;
                    Eurico.GetComponent<Interact>().mecano.SetActive(false);
                    Eurico.transform.position = new Vector3(227.5519f, 11.00361f, 48.78294f);
                    Eurico.GetComponent<CharacterController>().enabled = true;
                    audioSource.clip = song1;
                    audioSource.Play();
                    break;
                case "BajarPiso1B":
                    Eurico.GetComponent<CharacterController>().enabled = false;
                    Eurico.GetComponent<Interact>().currentInteractable.GetComponent<GlowObjectCmd>().running = false;
                    Eurico.GetComponent<Interact>().currentInteractable = null;
                    Eurico.GetComponent<Interact>().mecano.SetActive(false);
                    Eurico.transform.position = new Vector3(144.0755f, 11.0f, 31.59f);
                    Eurico.GetComponent<CharacterController>().enabled = true;
                    audioSource.clip = song1;
                    audioSource.Play();
                    break;
                case "SubirPiso2A":
                    Eurico.GetComponent<CharacterController>().enabled = false;
                    Eurico.GetComponent<Interact>().currentInteractable.GetComponent<GlowObjectCmd>().running = false;
                    Eurico.GetComponent<Interact>().currentInteractable = null;
                    Eurico.GetComponent<Interact>().mecano.SetActive(false);
                    Eurico.transform.position = new Vector3(445.57f, 23.74f, 30.91f);
                    Eurico.GetComponent<CharacterController>().enabled = true;
                    audioSource.clip = song2;
                    audioSource.Play();
                    break;
                case "SubirPiso2B":
                    Eurico.GetComponent<CharacterController>().enabled = false;
                    Eurico.GetComponent<Interact>().currentInteractable.GetComponent<GlowObjectCmd>().running = false;
                    Eurico.GetComponent<Interact>().currentInteractable = null;
                    Eurico.GetComponent<Interact>().mecano.SetActive(false);
                    Eurico.transform.position = new Vector3(362.9922f, 22.98f, 49.29f);
                    Eurico.GetComponent<CharacterController>().enabled = true;
                    audioSource.clip = song2;
                    audioSource.Play();
                    break;
                case "DestroyTrees":
                    FindObjectOfType<DestroyTrees>().CallDestroyTrees();
                    break;
                default:
                    break;
            }
            func = "";
        }
    }

    void ChangeToTrees()
    {
        SceneManager.LoadScene("TreeRoad");
    }

    public void callFadeToBlack(DialogueUI dialogue)
    {
        StartCoroutine(FadeToBlack(dialogue));
    }

    IEnumerator FadeToBlack(DialogueUI dialogue)
    {
        Color c = new Color(0, 0, 0, 0);
        Image img = FindObjectOfType<Canvas>().GetComponent<Image>();

        for (int i = 0; i <= 255; i++)
        {
            c.a = i;
            img.color = c;
            yield return new WaitForSeconds(0.005f);
        }

        //yield return new WaitForSeconds(0.1f);

        for (int j = 255; j >= 0; j--)
        {
            c.a = j;
            img.color = c;
            yield return new WaitForSeconds(0.005f);
        }

        if (dialogue != null)
            StartDialogue(dialogue);
    }
}
