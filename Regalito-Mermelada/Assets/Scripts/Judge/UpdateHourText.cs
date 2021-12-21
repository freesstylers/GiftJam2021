using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateHourText : MonoBehaviour
{
    TMPro.TextMeshProUGUI text;
    int auxH;
    int auxM;
    int auxS;
    string extraH = "";
    string extraM = "";
    string extraS = "";
    // Start is called before the first frame update
    void Start()
    {
        text = transform.GetChild(1).GetComponent<TMPro.TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        auxH = System.DateTime.Now.Hour;
        auxM = System.DateTime.Now.Minute;
        auxS = System.DateTime.Now.Second;

        if (auxH < 10)
            extraH = "0";
        else
            extraH = "";
        
        if (auxM < 10)
            extraM = "0";
        else
            extraM = "";

        if (auxS < 10)
            extraS = "0";
        else
            extraS = "";
        
        text.text = extraH + auxH + ":" + extraM + auxM + ":" + extraS + auxS;
    }
}
