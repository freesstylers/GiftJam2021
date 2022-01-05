using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActivateProblem : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void activateProblem()
    {
        int index = transform.GetSiblingIndex();
        GameObject.Find("Canvas/Problems").transform.GetChild(index).gameObject.SetActive(true);    //Activate Problem
        this.gameObject.GetComponent<Button>().interactable = false;
        GameObject.Find("Canvas/Overview").SetActive(false);    //Deactivate Overview
    }
}
