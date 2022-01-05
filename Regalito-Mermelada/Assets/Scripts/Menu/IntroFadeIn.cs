using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroFadeIn : MonoBehaviour
{
    public float timeToAppear_;
    public float timeToFade_;
    private float timer;
    private Image image;
    private bool aux = false;

    void Start()
    {
        timer = timeToFade_;
        image = GetComponent<Image>();
    }

    void Update()
    {
        if (timeToAppear_ <= 0.0f)
        {
            if (timeToFade_ > 0.0f)
            {
                timeToFade_ -= Time.deltaTime;
                Color tempColor = image.color;
                tempColor.a = (timeToFade_ / timer);
                image.color = tempColor;
            }
            else
            {
                if (!aux)
                {
                    //Si alguien ve esto, que mande un mensaje por el grupo diciendo "Gonzalo, que bien bailas bachata"
                    gameObject.SetActive(false);
                    aux = !aux;
                }
            }
        }
        else
        {
            timeToAppear_ -= Time.deltaTime;
        }
    }
}
