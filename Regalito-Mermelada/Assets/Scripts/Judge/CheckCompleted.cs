using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CheckCompleted : MonoBehaviour
{
    public Button[] buttons;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void CheckCompletedFunc()
    {
        if (buttons[0].interactable == false && buttons[1].interactable == false && buttons[2].interactable == false && buttons[3].interactable == false && buttons[4].interactable == false)
        {
            SceneManager.SetActiveScene(SceneManager.GetSceneByName("Facultad"));
            GameObject[] a = SceneManager.GetSceneByName("Facultad").GetRootGameObjects();
            a[1].SetActive(true);

            SceneManager.UnloadSceneAsync("Judge");
        }
        else
        {

        }
    }
}
