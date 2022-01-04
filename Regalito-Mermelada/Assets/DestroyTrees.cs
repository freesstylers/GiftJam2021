using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTrees : MonoBehaviour
{
    public GameObject[] trees;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void CallDestroyTrees()
    {
        foreach (GameObject g in trees)
            g.SetActive(false);
    }
}
