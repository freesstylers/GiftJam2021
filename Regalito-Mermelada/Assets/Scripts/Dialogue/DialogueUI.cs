using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Sentence
{
    [TextArea(1, 6)]
    public string sentence;

    public Sprite icon;
    public AudioClip sound;
}

[System.Serializable]
public class DialogueUI
{
    //public string name;

    public Sentence[] sentences;
    public bool function = false;
    public string functionName;
}
