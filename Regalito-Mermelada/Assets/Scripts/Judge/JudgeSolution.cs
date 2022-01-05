using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class JudgeSolution : MonoBehaviour
{
    int problem; int button;
    public bool problem0 = false;
    public bool problem1 = false;
    public bool problem2 = false;
    public bool problem3 = false;
    public bool problem4 = false;
    // Start is called before the first frame update
    bool isCorrect()
    {
        bool ret;

        problem = transform.parent.parent.GetSiblingIndex();
        button = transform.GetSiblingIndex();

        switch (problem)
        {
            case 0:
                if (button == 6)
                {
                    ret = true;
                    problem0 = true;
                }
                else
                    ret = false;
                break;
            case 1:
                if (button == 2)
                {
                    ret = true;
                    problem1 = true;
                }
                else
                    ret = false;
                break;
            case 2:
                if (button == 1)
                {
                    ret = true;
                    problem2 = true;
                }
                else
                    ret = false;
                break;
            case 3:
                if (button == 0)
                {
                    ret = true;
                    problem3 = true;
                }
                else
                    ret = false;
                break;
            case 4:
                if (button == 3)
                {
                    ret = true;
                    problem4 = true;
                }
                else
                    ret = false;
                break;
            default:
                ret = false;
                break;
        }

        return ret;
    }

    public void buttonClicked()
    {
        if (isCorrect())
        {
            Debug.Log("pog");
            //Play Sound

            //Return to overview
            StartCoroutine(backToOverview());
        }
        else
        {
            Debug.Log("no pog");

            //Play Sound
            //Deactivate button
            gameObject.GetComponent<Button>().interactable = false;
        }
    }

    IEnumerator backToOverview()
    {
        yield return new WaitForSeconds(1.0f); //Wait

        transform.parent.parent.parent.parent.GetChild(2).gameObject.SetActive(true);
        transform.parent.parent.gameObject.SetActive(false);

        TMPro.TextMeshProUGUI text = transform.parent.parent.parent.parent.GetChild(2).GetChild(0).GetChild(2).GetChild(problem).GetChild(3).GetComponent<TMPro.TextMeshProUGUI>();
        switch (problem)
        {
            case 0:
                text.text = "Wrong Answer";
                text.color = new Color(255, 0, 0);
                break;
            case 1:
                text.text = "Timelimit";
                text.color = new Color(255, 0, 0);
                break;
            case 2:
                text.text = "Compiler Error";
                text.color = new Color(255, 0, 0);
                break;
            case 3:
                text.text = "Correct";
                text.color = new Color(0, 255, 0);
                break;
            case 4:
                text.text = "Run Error";
                text.color = new Color(255, 0, 0);
                break;
            default:
                break;
        }

        FindObjectOfType<CheckCompleted>().CheckCompletedFunc();
    }
}
