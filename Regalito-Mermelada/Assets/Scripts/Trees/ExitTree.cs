using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitTree : MonoBehaviour
{
    float time = 0.0f;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (time < 1.0f)
            {
                time += Time.deltaTime;
            }
            else
            {
                SceneManager.LoadScene("Facultad");
            }
        }
        else
        {
            time = 0.0f;
        }
    }
}
