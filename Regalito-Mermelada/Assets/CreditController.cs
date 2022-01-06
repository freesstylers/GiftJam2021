using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreditController : MonoBehaviour
{
    public Text creditos;
    public Text agradecimientos;
    public Button exit;

    int i = 0;

    public void exitGame()
    {
        Application.Quit();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (creditos.gameObject.activeInHierarchy)
            {
                creditos.gameObject.SetActive(false);
                agradecimientos.gameObject.SetActive(true);
                i++;
            }
            else
            {
                creditos.gameObject.SetActive(true);
                agradecimientos.gameObject.SetActive(false);
                i++;
            }

            if (i >= 2)
                exit.gameObject.SetActive(true);
        }
    }
}
