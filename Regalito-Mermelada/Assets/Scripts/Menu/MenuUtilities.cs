using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUtilities : MonoBehaviour
{
    public Image black_;
    private bool changingScene_ = false;
    public float timeToFade_;
    private float timer;

    private bool aux = false;

    void Start()
    {
        timer = timeToFade_;
    }

    void Update()
    {
        if (changingScene_)
        {
            if (timeToFade_ > 0.0f)
            {
                timeToFade_ -= Time.deltaTime;
                Color tempColor = black_.color;
                tempColor.a = 1 - (timeToFade_ / timer);
                black_.color = tempColor;
            }
            else
            {
                SceneManager.LoadScene("Facultad");
            }
        }
    }

    public void Play()
    {
        black_.gameObject.SetActive(true);
        changingScene_ = true;
    }

    public void Twitter()
    {
        Application.OpenURL("https://twitter.com/FreeStylers_Dev");
    }

    public void RegalitoMermelada()
    {
        Application.OpenURL("https://itch.io/jam/gift-jam-2021");
    }
}
