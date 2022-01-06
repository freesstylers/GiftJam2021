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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (creditos.gameObject.activeInHierarchy)
            {

            }
            else
            {

            }
        }
    }
}
