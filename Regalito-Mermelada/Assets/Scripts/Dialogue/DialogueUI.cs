using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DialogueUI
{
    public string name;

    [TextArea(1, 4)]
    public string[] sentences;
    public bool function = false;
    public string functionName;
}
