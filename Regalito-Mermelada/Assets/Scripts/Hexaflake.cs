using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hexaflake : MonoBehaviour
{
    [SerializeField]
    float timeToChange = 0.05f;

    float auxTime = 0.0f;
    int level = 0;
    int color = 0;
    Color[] hexacolor;

    void Start()
    {
        transform.GetChild(0).gameObject.SetActive(true);
        transform.GetChild(1).gameObject.SetActive(false);
        transform.GetChild(2).gameObject.SetActive(false);

        hexacolor = new Color[7];

        hexacolor[0] = new Color(255, 51, 0, 255);
        hexacolor[1] = new Color(255, 153, 0, 255);
        hexacolor[2] = new Color(255, 255, 0, 255);
        hexacolor[3] = new Color(153, 255, 51, 255);
        hexacolor[4] = new Color(0, 255, 255, 255);
        hexacolor[5] = new Color(0, 102, 255, 255);
        hexacolor[6] = new Color(153, 51, 255, 255);
    }

    void Update()
    {
        auxTime += Time.deltaTime;

        if (auxTime > timeToChange)
        {
            if (color < 6)
            {
                color++;

                if (level != 2)
                {
                    for (int j = 0; j < transform.GetChild(level).childCount; j++)
                        transform.GetChild(level).GetChild(j).GetComponent<SpriteRenderer>().color = hexacolor[color];
                }
                else
                {
                    for (int k = 0; k < 3; k++)
                    {
                        for (int j = 0; j < transform.GetChild(level).GetChild(k).childCount; j++)
                        {
                            for (int l = 0; l < transform.GetChild(level).GetChild(k).GetChild(j).childCount; l++)
                            {
                                transform.GetChild(level).GetChild(k).GetChild(j).GetChild(l).GetComponent<SpriteRenderer>().color = hexacolor[color];
                            }

                        }
                    }
                }
            }
            else
            {
                if (level < 2)
                    level++;
                else
                    level = 0;

                color = 0;

                for (int i = 0; i < transform.childCount; i++)
                {
                    if (i == level)
                    {
                        transform.GetChild(i).gameObject.SetActive(true);
                    }
                    else
                        transform.GetChild(i).gameObject.SetActive(false);
                }
            }
            

            auxTime = 0.0f;
        }
        
    }
}
