using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueBoxSprite : MonoBehaviour
{
    public Sprite[] faces;
    // Start is called before the first frame update
    void setSprite(DialogueUI dialogue)
    {

        switch (dialogue.name)
        {
            case "Pepin":
                transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = faces[0];
                break;
            case "Abundio":
                transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = faces[1];
                break;
            case "Hexcules":
                transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = faces[2];
                break;
            case "Hextor":
                transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = faces[3];
                break;
            default:
                transform.parent.gameObject.SetActive(false);
                break;
        }
    }
}
