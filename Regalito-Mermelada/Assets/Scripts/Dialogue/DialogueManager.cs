using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Diagnostics;

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
    
    public GameObject Facultad;
    public GameObject Arboles;
    public GameObject Jueza;

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
                case "Creditos":
                    SceneManager.LoadScene("Creditos");
                    break;
                case "Trees":
                    Facultad.SetActive(false);
                    Arboles.SetActive(true);
                    break;
                case "BajarAscensor":
                    Eurico.GetComponent<CharacterController>().enabled = false;
                    Eurico.GetComponent<Interact>().currentInteractable.GetComponent<GlowObjectCmd>().running = false;
                    Eurico.GetComponent<Interact>().currentInteractable = null;
                    Eurico.GetComponent<Interact>().mecano.SetActive(false);
                    Eurico.transform.localPosition = new Vector3(-239.94f, 33.06f, 13.83f);
                    Eurico.GetComponent<CharacterController>().enabled = true;
                    audioSource.clip = song3;
                    audioSource.Play();
                    break;
                case "SubirAscensor":
                    Eurico.GetComponent<CharacterController>().enabled = false;
                    Eurico.GetComponent<Interact>().currentInteractable.GetComponent<GlowObjectCmd>().running = false;
                    Eurico.GetComponent<Interact>().currentInteractable = null;
                    Eurico.GetComponent<Interact>().mecano.SetActive(false);
                    Eurico.transform.localPosition = new Vector3(109.14f, 32.72f, 8.73f);
                    Eurico.GetComponent<CharacterController>().enabled = true;
                    audioSource.clip = song1;
                    audioSource.Play();
                    break;
                case "BajarPiso0A":
                    Eurico.GetComponent<CharacterController>().enabled = false;
                    Eurico.GetComponent<Interact>().currentInteractable.GetComponent<GlowObjectCmd>().running = false;
                    Eurico.GetComponent<Interact>().currentInteractable = null;
                    Eurico.GetComponent<Interact>().mecano.SetActive(false);
                    Eurico.transform.localPosition = new Vector3(113.82f, 32.72f, 22.63f);
                    Eurico.GetComponent<CharacterController>().enabled = true;
                    break;
                case "BajarPiso0B":
                    Eurico.GetComponent<CharacterController>().enabled = false;
                    Eurico.GetComponent<Interact>().currentInteractable.GetComponent<GlowObjectCmd>().running = false;
                    Eurico.GetComponent<Interact>().currentInteractable = null;
                    Eurico.GetComponent<Interact>().mecano.SetActive(false);
                    Eurico.transform.localPosition = new Vector3(25.47029f, 32.72f, 22.63f);
                    Eurico.GetComponent<CharacterController>().enabled = true;
                    break;
                case "SubirPiso1A":
                    Eurico.GetComponent<CharacterController>().enabled = false;
                    Eurico.GetComponent<Interact>().currentInteractable.GetComponent<GlowObjectCmd>().running = false;
                    Eurico.GetComponent<Interact>().currentInteractable = null;
                    Eurico.GetComponent<Interact>().mecano.SetActive(false);
                    Eurico.transform.localPosition = new Vector3(295.342f, 42.21f, 4.92f);
                    Eurico.GetComponent<CharacterController>().enabled = true;
                    break;
                case "SubirPiso1B":
                    Eurico.GetComponent<CharacterController>().enabled = false;
                    Eurico.GetComponent<Interact>().currentInteractable.GetComponent<GlowObjectCmd>().running = false;
                    Eurico.GetComponent<Interact>().currentInteractable = null;
                    Eurico.GetComponent<Interact>().mecano.SetActive(false);
                    Eurico.transform.localPosition = new Vector3(212.64f, 42.21f, 22.23f);
                    Eurico.GetComponent<CharacterController>().enabled = true;
                    break;
                case "BajarPiso1A":
                    Eurico.GetComponent<CharacterController>().enabled = false;
                    Eurico.GetComponent<Interact>().currentInteractable.GetComponent<GlowObjectCmd>().running = false;
                    Eurico.GetComponent<Interact>().currentInteractable = null;
                    Eurico.GetComponent<Interact>().mecano.SetActive(false);
                    Eurico.transform.localPosition = new Vector3(295.342f, 42.21f, 22.23f);
                    Eurico.GetComponent<CharacterController>().enabled = true;
                    audioSource.clip = song1;
                    audioSource.Play();
                    break;
                case "BajarPiso1B":
                    Eurico.GetComponent<CharacterController>().enabled = false;
                    Eurico.GetComponent<Interact>().currentInteractable.GetComponent<GlowObjectCmd>().running = false;
                    Eurico.GetComponent<Interact>().currentInteractable = null;
                    Eurico.GetComponent<Interact>().mecano.SetActive(false);
                    Eurico.transform.localPosition = new Vector3(212.64f, 42.21f, 4.9f);
                    Eurico.GetComponent<CharacterController>().enabled = true;
                    audioSource.clip = song1;
                    audioSource.Play();
                    break;
                case "SubirPiso2A":
                    Eurico.GetComponent<CharacterController>().enabled = false;
                    Eurico.GetComponent<Interact>().currentInteractable.GetComponent<GlowObjectCmd>().running = false;
                    Eurico.GetComponent<Interact>().currentInteractable = null;
                    Eurico.GetComponent<Interact>().mecano.SetActive(false);
                    Eurico.transform.localPosition = new Vector3(514f, 53.94f, 5.27f);
                    Eurico.GetComponent<CharacterController>().enabled = true;
                    audioSource.clip = song2;
                    audioSource.Play();
                    break;
                case "SubirPiso2B":
                    Eurico.GetComponent<CharacterController>().enabled = false;
                    Eurico.GetComponent<Interact>().currentInteractable.GetComponent<GlowObjectCmd>().running = false;
                    Eurico.GetComponent<Interact>().currentInteractable = null;
                    Eurico.GetComponent<Interact>().mecano.SetActive(false);
                    Eurico.transform.localPosition = new Vector3(430.67f, 53.94f, 23.97f);
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
        Eurico.GetComponent<Interact>().currentInteractable.GetComponent<GlowObjectCmd>().running = false;
        Eurico.GetComponent<Interact>().currentInteractable = null;
        Eurico.GetComponent<Interact>().mecano.SetActive(false);

        AsyncOperation aO = SceneManager.LoadSceneAsync("TreeRoad", LoadSceneMode.Additive);
        GameObject.Find("Facultad").SetActive(false);

        StartCoroutine(setActiveSceneTree(aO));
    }

    IEnumerator setActiveSceneTree(AsyncOperation aO)
    {
        while (!aO.isDone)
            yield return null;

        SceneManager.SetActiveScene(SceneManager.GetSceneByName("TreeRoad"));
    } 
    
    void ChangeToJueza()
    {
        AsyncOperation aO = SceneManager.LoadSceneAsync("Judge", LoadSceneMode.Additive);
        GameObject.Find("Facultad").SetActive(false);

        StartCoroutine(setActiveSceneJueza(aO));
    }

    IEnumerator setActiveSceneJueza(AsyncOperation aO)
    {
        while (!aO.isDone)
            yield return null;

        SceneManager.SetActiveScene(SceneManager.GetSceneByName("Judge"));
    }

    public void callFadeToBlack(DialogueUI dialogue)
    {
        StartCoroutine(FadeToBlack(dialogue));
    }

    IEnumerator FadeToBlack(DialogueUI dialogue)
    {
        Color c = new Color(0, 0, 0, 0);
        Image img = FindObjectOfType<Canvas>().GetComponent<Image>();

        c.a = 255;
        img.color = c;

        yield return new WaitForSeconds(0.5f);
        
        c.a = 0;
        img.color = c;

        if (dialogue != null)
            StartDialogue(dialogue);
    }
}
